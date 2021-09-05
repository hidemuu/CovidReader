using CovidReader.Models;
using CovidReader.Models.Api;
using CovidReader.Models.Covid;
using CovidReader.Plugins.Charts;
using CovidReader.Plugins.DataAccesses;
using CovidReader.Plugins.Utilities;
using CovidReader.Repository;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core
{
    

    public class ApiService
    {
        private ApiRepositoryHelper _apihelper;
        private CovidRepositoryHelper _covidhelper;
        private IApiRepository _apiRepository;
        private ICovidRepository _covidRepository;

        public ApiService(IApiRepository repository, ICovidRepository covids)
        {
            _apiRepository = repository;
            _covidRepository = covids;
            _apihelper = new ApiRepositoryHelper(repository);
            _covidhelper = new CovidRepositoryHelper(covids);
        }

        public async Task<IEnumerable<DbObject>> GetApiAsync(string table)
        {
            switch (table)
            {
                case "virus": return await _apihelper.GetAsync<Virus>();
                case "chartitem": return await _apihelper.GetAsync<ChartItem>();
                case "chartconfig": return await _apihelper.GetAsync<ChartConfig>();
                default: return await _apihelper.GetAsync<Virus>();
            }
        }

        public async Task<IEnumerable<CovidDbObject>> GetCovidAsync(string table)
        {
            switch (table)
            {
                case "death": return await _covidhelper.GetAsync<Death>();
                case "hospitalization": return await _covidhelper.GetAsync<Hospitalization>();
                default: return await _covidhelper.GetAsync<Death>();
            }
        }

        /// <summary>
        /// 外部データをリポジトリにインポート
        /// </summary>
        /// <param name="repository">インポート元外部データ</param>
        /// <returns></returns>
        public async Task ImportCovidAsync(ICovidRepository repository)
        {
            Console.WriteLine("Importing...");
            await _covidhelper.ImportAsync(repository);
        }
        /// <summary>
        /// リポジトリデータを外部にエクスポート
        /// </summary>
        /// <param name="repository">エクスポート先外部データ</param>
        /// <returns></returns>
        public async Task ExportApiAsync(IApiRepository repository)
        {
            Console.WriteLine("Exporting...");
            await _apihelper.ExportAsync(repository);
        }

        /// <summary>
        /// リポジトリデータを外部にエクスポート
        /// </summary>
        /// <param name="repository">エクスポート先外部データ</param>
        /// <returns></returns>
        public async Task ExportCovidAsync(ICovidRepository repository)
        {
            Console.WriteLine("Exporting...");
            await _covidhelper.ExportAsync(repository);
        }

        /// <summary>
        /// VirusテーブルデータをChartItemテーブルに変換して格納 / ChartConfigテーブルデータを更新
        /// </summary>
        /// <returns></returns>
        public async Task PostVirusToChartItemAsync()
        {

            var chartConfigs = ChartItemBuilder.GetChartConfigs();
            var viruses = await _apihelper.GetAsync<Virus>();
            var chartItems = ChartItemBuilder.GetChartItems(viruses);
            
            Console.WriteLine("Exporting...");
            await _apihelper.ExportAsync(_apiRepository, chartItems);
            await _apihelper.ExportAsync(_apiRepository, chartConfigs);
        }

        /// <summary>
        /// ChartItem / ChartConfigを指定外部データにエクスポート
        /// </summary>
        /// <param name="repository">出力先データ</param>
        /// <returns></returns>
        public async Task ExportChartItemAsync(IApiRepository repository)
        {

            Console.WriteLine("Exporting...");
            await _apihelper.ExportAsync(repository, await _apiRepository.ChartItems.GetAsync());
            await _apihelper.ExportAsync(repository, await _apiRepository.ChartConfigs.GetAsync());
        }

        /// <summary>
        /// CovidデータベースデータをApiデータベースのVirusテーブルに格納
        /// </summary>
        /// <returns></returns>
        public async Task PostCovidToApiAsync()
        {
            List<Virus> items = new List<Virus>();
            var lineItems = await _covidhelper.GetAsync<CovidLineItem>();
            
            var count = 0;
            foreach (var item in lineItems)
            {

                var testDetail = (await _covidhelper.GetAsync<TestDetail>()).FirstOrDefault(x => x.Date == item.Date);
                var nationalTestNumber = 0;
                var quarantineTestNumber = 0;
                var careCenterTestNumber = 0;
                var civilCenterTestNumber = 0;
                var collegeTestNumber = 0;
                var medicalTestNumber = 0;
                if(testDetail != null)
                {
                    nationalTestNumber = DataConverter.StringToInt(testDetail.Number);
                    quarantineTestNumber = DataConverter.StringToInt(testDetail.QuarantineNumber);
                    careCenterTestNumber = DataConverter.StringToInt(testDetail.CareCenterNumber);
                    civilCenterTestNumber = DataConverter.StringToInt(testDetail.CivilCenterNumber);
                    collegeTestNumber = DataConverter.StringToInt(testDetail.CollegeNumber);
                    medicalTestNumber = DataConverter.StringToInt(testDetail.MedicalNumber);
                }

                items.Add(new Virus
                {
                    Id = count,
                    Date = item.Date,
                    Name = "",
                    DeathNumber = CovidDbObjectToInt((await _covidhelper.GetAsync<Death>()).FirstOrDefault(x => x.Date == item.Date)),
                    HospitalizationNumber = CovidDbObjectToInt((await _covidhelper.GetAsync<Hospitalization>()).FirstOrDefault(x => x.Date == item.Date)),
                    PositiveNumber = CovidDbObjectToInt((await _covidhelper.GetAsync<Positive>()).FirstOrDefault(x => x.Date == item.Date)),
                    RecoveryNumber = CovidDbObjectToInt((await _covidhelper.GetAsync<Recovery>()).FirstOrDefault(x => x.Date == item.Date)),
                    TestNumber = CovidDbObjectToInt((await _covidhelper.GetAsync<Test>()).FirstOrDefault(x => x.Date == item.Date)),
                    NationalTestNumber = nationalTestNumber,
                    QuarantineTestNumber = quarantineTestNumber,
                    CareCenterTestNumber = careCenterTestNumber,
                    CivilCenterTestNumber = civilCenterTestNumber,
                    CollegeTestNumber = collegeTestNumber,
                    MedicalTestNumber = medicalTestNumber,
                });
                count++;
            }

            Console.WriteLine("Posting[Covid->Api-Viruses]...");
            //var data = ApiRepositoryUseCase.UseData(key);
            await _apihelper.ExportAsync(_apiRepository, items);
        }

        private static int CovidDbObjectToInt(CovidDbObject obj)
        {
            if(obj != null)
            {
                return DataConverter.StringToInt(obj.Number, 0);
            }
            else
            {
                return 0;
            }
        }


        //private async Task InitializeAsync()
        //{
        //    var apiDb = (await _settingRepository.Configs.GetAsync("ApiDB")).Val;
        //    var covidDb = (await _settingRepository.Configs.GetAsync("CovidDB")).Val;
        //}

    }
}
