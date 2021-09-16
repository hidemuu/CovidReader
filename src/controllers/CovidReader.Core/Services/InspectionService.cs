using CovidReader.Core.Utilities;
using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Services
{
    public class InspectionService : IRepositoryService<IInspectionRepository>
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
        public async Task ImportAsync(IInspectionRepository imports)
        {
            await _repository.PostAsync(await imports.GetAsync());
        }

        /// <summary>
        /// 指定外部データにリポジトリデータをエクスポート
        /// </summary>
        /// <param name="exports">出力先外部データ</param>
        /// <returns></returns>
        public async Task ExportAsync(IInspectionRepository exports)
        {
            await exports.PostAsync(await _repository.GetAsync());
        }

        public async Task CreateAsync(ICovid19Repository covid19s)
        {
            //キーデータ取得
            var dates = await GetDatesAsync(covid19s);
            var dailys = await CreateDailyAsync(covid19s, dates);
            var totals = await CreateTotalAsync(dailys.ToList(), dates);

            await _repository.PostAsync(dailys);
            await _repository.PostAsync(totals);
        }

        public async Task<IEnumerable<Inspection>> CreateDailyAsync(ICovid19Repository covid19s, IList<string> dates)
        {
            var items = new List<Inspection>();
            var count = 0;

            //感染データ取得

            foreach (var date in dates)
            {
                var testDetail = (await covid19s.TestDetails.GetAsync()).FirstOrDefault(x => x.Date == date);
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

        private static async Task<IList<string>> GetDatesAsync(ICovid19Repository covid19s)
        {
            //キーデータ取得
            var lineItems = (await covid19s.CovidLineItems.GetAsync()).OrderBy(x => DateTime.Parse(x.Date));
            var dates = new List<string>();
            foreach (var item in lineItems)
            {
                dates.Add(item.Date);
            }
            return dates;
        }

    }
}
