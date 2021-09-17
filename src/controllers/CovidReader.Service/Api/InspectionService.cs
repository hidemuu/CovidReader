using CovidReader.Core.Utilities;
using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using CovidReader.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Services
{
    public class InspectionService : IInspectionService
    {
        private IInspectionRepository _repository;

        public InspectionService(IInspectionRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository", "A valid repository must be supplied.");
            }
            _repository = repository;
        }

        /// <summary>
        /// 指定外部データをリポジトリにインポート
        /// </summary>
        /// <param name="imports">外部データ</param>
        /// <returns></returns>
        public async Task PostAsync(IEnumerable<Inspection> items)
        {
            await _repository.PostAsync(items);
        }

        public async Task<IEnumerable<Inspection>> GetAsync()
        {
            return await _repository.GetAsync();
        }


        public async Task CreateAsync(IList<string> dates, IEnumerable<TestDetail> testDetails)
        {
            var dailys = await CreateDailyAsync(dates, testDetails);
            var totals = await CreateTotalAsync(dailys.ToList(), dates);

            await _repository.PostAsync(dailys);
            await _repository.PostAsync(totals);
        }

        public async Task<IEnumerable<Inspection>> CreateDailyAsync(IList<string> dates, IEnumerable<TestDetail> testDetails)
        {
            var items = new List<Inspection>();
            var count = 0;

            //感染データ取得
            await Task.Run(() => 
            {
                foreach (var date in dates)
                {
                    var testDetail = testDetails.FirstOrDefault(x => x.Date == date);
                    if (testDetail != null)
                    {
                        items.Add(new Inspection
                        {
                            Index = count,
                            Date = date,
                            CountryName = "Japan",
                            Calc = "daily",
                            NationalTestNumber = DataConverter.StringToInt(testDetail.Number),
                            QuarantineTestNumber = DataConverter.StringToInt(testDetail.QuarantineNumber),
                            CareCenterTestNumber = DataConverter.StringToInt(testDetail.CareCenterNumber),
                            CivilCenterTestNumber = DataConverter.StringToInt(testDetail.CivilCenterNumber),
                            CollegeTestNumber = DataConverter.StringToInt(testDetail.CollegeNumber),
                            MedicalTestNumber = DataConverter.StringToInt(testDetail.MedicalNumber),
                        });
                    }
                    count++;
                }
            });
            
            return items;
        }

        public async Task<IEnumerable<Inspection>> CreateTotalAsync(IList<Inspection> inspections, IList<string> dates)
        {

            var nationalTestSums = (int[])DataConverter.UnitToSum(inspections.Select(x => x.NationalTestNumber).ToArray());
            var quarantineTestSums = (int[])DataConverter.UnitToSum(inspections.Select(x => x.QuarantineTestNumber).ToArray());
            var careCenterTestSums = (int[])DataConverter.UnitToSum(inspections.Select(x => x.CareCenterTestNumber).ToArray());
            var civilCenterTestSums = (int[])DataConverter.UnitToSum(inspections.Select(x => x.CivilCenterTestNumber).ToArray());
            var collegeTestSums = (int[])DataConverter.UnitToSum(inspections.Select(x => x.CollegeTestNumber).ToArray());
            var medicalTestSums = (int[])DataConverter.UnitToSum(inspections.Select(x => x.MedicalTestNumber).ToArray());

            var result = new List<Inspection>();

            await Task.Run(() =>
            {
                var count = 0;
                foreach (var date in dates)
                {
                    result.Add(new Inspection
                    {
                        Index = count,
                        Date = date,
                        CountryName = "Japan",
                        Calc = "total",
                        NationalTestNumber = nationalTestSums[count],
                        QuarantineTestNumber = quarantineTestSums[count],
                        CareCenterTestNumber = careCenterTestSums[count],
                        CivilCenterTestNumber = civilCenterTestSums[count],
                        CollegeTestNumber = collegeTestSums[count],
                        MedicalTestNumber = medicalTestSums[count],
                    });

                    count++;
                }
            });

            return result;
        }

        

    }
}
