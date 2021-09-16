using CovidReader.Core.Services;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public class ApiController
    {
        public IApiRepository ApiRepository { get; }
        public ICovid19Repository Covid19Repository { get; }

        private InfectionService _infectionService;
        private InspectionService _inspectionService;
        private ChartItemService _chartItemService;
        private ChartConfigService _chartConfigService;
        private Covid19Service _covid19Service;

        public ApiController(IApiRepository api, ICovid19Repository covids)
        {
            if (api == null) throw new ArgumentNullException("apiRepository");
            ApiRepository = api;
            _infectionService = new InfectionService(api.Infections);
            _inspectionService = new InspectionService(api.Inspections);
            _chartItemService = new ChartItemService(api.ChartItems);
            _chartConfigService = new ChartConfigService(api.ChartConfigs);
            if (covids == null) throw new ArgumentNullException("covidRepository");
            Covid19Repository = covids;
            _covid19Service = new Covid19Service(covids);
        }


        /// <summary>
        /// 外部データをリポジトリにインポート
        /// </summary>
        /// <param name="repository">インポート元外部データ</param>
        /// <returns></returns>
        public async Task ImportAsync(ICovid19Repository repository)
        {
            Console.WriteLine("Importing...");
            await _covid19Service.ImportAsync(repository);
        }

        /// <summary>
        /// リポジトリデータを外部にエクスポート
        /// </summary>
        /// <param name="repository">エクスポート先外部データ</param>
        /// <returns></returns>
        public async Task ExportAsync(ICovid19Repository repository)
        {
            Console.WriteLine("Exporting...");
            await _covid19Service.ExportAsync(repository);
        }

        /// <summary>
        /// リポジトリデータを外部にエクスポート
        /// </summary>
        /// <param name="repository">エクスポート先外部データ</param>
        /// <returns></returns>
        public async Task ExportAsync(IApiRepository repository)
        {
            Console.WriteLine("Exporting...");
            await _infectionService.ExportAsync(repository.Infections);
            await _inspectionService.ExportAsync(repository.Inspections);
            await _chartItemService.ExportAsync(repository.ChartItems);
            await _chartConfigService.ExportAsync(repository.ChartConfigs);
        }


        /// <summary>
        /// CovidデータベースデータをApiデータベーステーブルに格納
        /// </summary>
        /// <returns></returns>
        public async Task CovidToApiAsync()
        {
            await _infectionService.CreateAsync(Covid19Repository);
            await _inspectionService.CreateAsync(Covid19Repository);
            
        }

        /// <summary>
        /// VirusテーブルデータをChartItemテーブルに変換して格納 / ChartConfigテーブルデータを更新
        /// </summary>
        /// <returns></returns>
        public async Task ToChartItemAsync()
        {
            await _chartItemService.CreateAsync(await ApiRepository.Infections.GetAsync());
        }


        //private async Task InitializeAsync()
        //{
        //    var apiDb = (await _settingRepository.Configs.GetAsync("ApiDB")).Val;
        //    var covidDb = (await _settingRepository.Configs.GetAsync("CovidDB")).Val;
        //}
    }
}
