using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Linq;
using CovidReader.Models;
using CovidReader.Core;
using CovidReader.Core.Service;

namespace CovidReader.Controllers
{
    public class ConsoleController : ApiController
    {
        //private ISettingRepository _settingRepository;
        private ChromeDriver _chrome;

        public ConsoleController(IApiService api, ICovid19Service covid19) : base(api, covid19)
        {
            //_settingRepository = new XmlSettingRepository(Constants.RootPath + @"assets\settings");
            //Task.WaitAll(InitializeAsync());

        }

        #region APIコマンド

        public async Task GetAsync()
        {
            await Task.Run(() => { });
        }

        
        public async Task GetChartItemAsync()
        {
            await ToChartItemAsync();
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
            //await ExportAsync(ApiRepositoryUseCase.UseJson(@"dist"));

            await Task.Run(() => 
            {
                Api.CopyChartItem();
            });

            return Api.RunServerProcess();

        }

        

        #endregion

        

    }
}
