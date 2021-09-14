using CovidReader.Models.Api;
using CovidReader.Repository;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using CovidReader.Repository.Settings;
using CovidReader.Repository.Settings.Xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using CovidReader.Models.Covid19.MHLW;
using System.Linq;
using CovidReader.Models;
using CovidReader.Core;
using CovidReader.Controllers.UseCases;

namespace CovidReader.Controllers
{
    public class ConsoleController : IController
    {
        //private ISettingRepository _settingRepository;
        private ApiService _apiService;
        private static Process _process;
        private ChromeDriver _chrome;
        private IApiRepository _apiRepository;
        private ICovidRepository _covidRepository;

        public ConsoleController(IApiRepository repository, ICovidRepository covids)
        {
            //_settingRepository = new XmlSettingRepository(Constants.RootPath + @"assets\settings");
            //Task.WaitAll(InitializeAsync());
            _apiRepository = repository;
            _covidRepository = covids;
            _apiService = new ApiService(repository, covids);

        }

        public IApiRepository GetApiRepository()
        {
            return _apiRepository;
        }

        public ICovidRepository GetCovidRepository()
        {
            return _covidRepository;
        }

        #region APIコマンド

        public async Task GetAsync()
        {
            await Task.Run(() => { });
        }

        public async Task ImportAsync()
        {
            await _apiService.ImportAsync(CovidRepositoryUseCase.UseCsv());
        }

        public async Task UpdateAsync()
        {
            await ImportAsync();
            await _apiService.CovidToApiAsync();
            await GetChartItemAsync();
        }

        public async Task GetChartItemAsync()
        {
            await _apiService.ToChartItemAsync();
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
            await _apiService.ExportAsync(ApiRepositoryUseCase.UseJson(@"dist"));
            //データをdist / サーバにコピー
            //File.Copy(
            //    Urls.RootPath + @"assets\api\chart_item.json",
            //    Urls.RootPath + @"dist\chart_item.json",
            //    true);
            File.Copy(
                Urls.RootPath + @"dist\chart_item.json",
                Urls.ServerPath + @"chart_item.json",
                true);

            //File.Copy(
            //    Urls.RootPath + @"assets\api\chart_config.json",
            //    Urls.RootPath + @"dist\chart_config.json",
            //    true);
            File.Copy(
                Urls.RootPath + @"dist\chart_config.json",
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

        

        #endregion

        

    }
}
