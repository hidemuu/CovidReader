using CovidReader.Models.Api;
using CovidReader.Repository;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid;
using CovidReader.Repository.Settings;
using CovidReader.Repository.Settings.Xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using CovidReader.Models.Covid;
using System.Linq;
using CovidReader.Models;

namespace CovidReader.Controllers
{
    public class AppController : IController
    {
        //private ISettingRepository _settingRepository;
        private ApiRepositoryHelper _api;
        private CovidRepositoryHelper _covid;
        private static Process _process;
        private ChromeDriver _chrome;

        public AppController(IApiRepository repository, ICovidRepository covids)
        {
            //_settingRepository = new XmlSettingRepository(Constants.RootPath + @"assets\settings");
            //Task.WaitAll(InitializeAsync());
            _api = new ApiRepositoryHelper(repository);
            _covid = new CovidRepositoryHelper(covids);
        }

        #region APIコマンド

        public async Task UpdateAsync()
        {
            await ImportCovidAsync(DbTypeKeys.Csv);
            await ConvertCovid2ApiAsync(DbTypeKeys.Sql);
        }

        public async Task AutoRunAsync()
        {
            await ViewChartAsync();
        }

        public async Task ScrapingAsync()
        {
            _chrome = new ChromeDriver();
            await Task.Run(() => 
            {
                _chrome.Url = "https://www.google.com/";
            });
        }

        public async Task<bool> ViewChartAsync()
        {
            await ExportChartItemAsync();
            //データをdist / サーバにコピー
            File.Copy(
                Urls.RootPath + @"assets\api\chart_item.json",
                Urls.RootPath + @"dist\chart_item.json",
                true);
            File.Copy(
                Urls.RootPath + @"assets\api\chart_item.json",
                Urls.ServerPath + @"chart_item.json",
                true);

            File.Copy(
                Urls.RootPath + @"assets\api\chart_config.json",
                Urls.RootPath + @"dist\chart_config.json",
                true);
            File.Copy(
                Urls.RootPath + @"assets\api\chart_config.json",
                Urls.ServerPath + @"chart_config.json",
                true);

            //スクリプトをサーバ内にコピー
            File.Copy(
                Urls.RootPath + @"scripts\js-html\index.html",
                Urls.ServerPath + @"index.html",
                true
                );
            File.Copy(
                Urls.RootPath + @"scripts\js-html\index.js",
                Urls.ServerPath + @"index.js",
                true
                );
            File.Copy(
                Urls.RootPath + @"scripts\js-html\chart.html",
                Urls.ServerPath + @"chart.html",
                true
                );
            File.Copy(
                Urls.RootPath + @"scripts\js-html\chart_draw.js",
                Urls.ServerPath + @"chart_draw.js",
                true
                );
            File.Copy(
                Urls.RootPath + @"scripts\js-html\table.html",
                Urls.ServerPath + @"table.html",
                true
                );
            File.Copy(
                Urls.RootPath + @"scripts\js-html\table.js",
                Urls.ServerPath + @"table.js",
                true
                );


            using (_process = new Process())
            {
                _process.StartInfo.UseShellExecute = true;
                _process.StartInfo.FileName = "chrome.exe";
                _process.StartInfo.Arguments = Urls.ServerUrl + @"index.html";
                _process.StartInfo.CreateNoWindow = true;
                return _process.Start();
            }
        }

        public async Task<string> GetApiAsync()
        {
            await _api.GetAsync<Virus>();
            return "";
        }

        public async Task<string> GetCovidAsync(string code)
        {
            switch (code.ToLower())
            {
                case "death": await _covid.GetAsync<Death>(); break;
            }

            return "";
        }

        #endregion

        #region 内部ロジック

        private async Task ImportCovidAsync(DbTypeKeys key = DbTypeKeys.Csv)
        {
            if (key == DbTypeKeys.None) return;
            Console.WriteLine("Importing...");
            var data = CovidRepositoryUseCase.UseData(key);
            await _covid.ImportAsync(data);
        }

        private async Task ExportApiAsync()
        {
            Console.WriteLine("Exporting...");
            var data = ApiRepositoryUseCase.UseData(DbTypeKeys.Json);
            await _api.ExportAsync(data);
        }

        private async Task ExportCovidAsync()
        {
            Console.WriteLine("Exporting...");
            var data = CovidRepositoryUseCase.UseData(DbTypeKeys.Json);
            await _covid.ExportAsync(data);
        }

        private async Task ExportChartItemAsync()
        {
            List<ChartItem> chartItems = new List<ChartItem>();
            List<ChartConfig> chartConfigs = new List<ChartConfig>();
            var covids = await _api.GetAsync<Virus>();
            foreach (var item in covids)
            {
                chartItems.Add(new ChartItem { 
                    Id = item.Id,
                    Date = item.Date, 
                    Data = item.DeathNumber.ToString() + Formats.Delimiter +
                           item.HospitalizationNumber.ToString() + Formats.Delimiter +
                           item.PositiveNumber.ToString() + Formats.Delimiter +
                           item.RecoveryNumber.ToString(),
                    });
            }

            chartConfigs.Add(new ChartConfig {
                Id = 0,
                Date = DateTime.Now.ToString(),
                Name = "Death",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(255,0,0,1)",
                BorderWidth = 1,
            });

            chartConfigs.Add(new ChartConfig
            {
                Id = 1,
                Date = DateTime.Now.ToString(),
                Name = "Hospitalization",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(0,255,0,1)",
                BorderWidth = 1,
            });

            chartConfigs.Add(new ChartConfig
            {
                Id = 2,
                Date = DateTime.Now.ToString(),
                Name = "Positive",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(0,0,255,1)",
                BorderWidth = 1,
            });

            chartConfigs.Add(new ChartConfig
            {
                Id = 3,
                Date = DateTime.Now.ToString(),
                Name = "Recovery",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            Console.WriteLine("Exporting...");
            var data = ApiRepositoryUseCase.UseData(DbTypeKeys.Json);
            await _api.ExportAsync(data, chartItems);
            await _api.ExportAsync(data, chartConfigs);
        }



        private async Task ConvertCovid2ApiAsync(DbTypeKeys key)
        {
            if (key == DbTypeKeys.None) return;
            List<Virus> items = new List<Virus>();
            var deathes = await _covid.GetAsync<Death>();
            var hospitalizations = await _covid.GetAsync<Hospitalization>();
            var positives = await _covid.GetAsync<Positive>();
            var recoveries = await _covid.GetAsync<Recovery>();
            var count = 0;
            foreach (var item in deathes)
            {
                items.Add(new Virus {
                    Id = count,
                    Date = item.Date, 
                    DeathNumber = int.Parse(item.Number),
                    HospitalizationNumber = int.Parse(hospitalizations.FirstOrDefault(x => x.Date == item.Date).Number),
                    PositiveNumber = int.Parse(positives.FirstOrDefault(x => x.Date == item.Date).Number),
                    RecoveryNumber = int.Parse(recoveries.FirstOrDefault(x => x.Date == item.Date).Number),
                });
                count++;
            }
            
            Console.WriteLine("Exporting...");
            var data = ApiRepositoryUseCase.UseData(key);
            await _api.ExportAsync(data, items);
        }


        //private async Task InitializeAsync()
        //{
        //    var apiDb = (await _settingRepository.Configs.GetAsync("ApiDB")).Val;
        //    var covidDb = (await _settingRepository.Configs.GetAsync("CovidDB")).Val;
        //}

        #endregion

    }
}
