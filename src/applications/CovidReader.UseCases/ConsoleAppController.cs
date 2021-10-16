using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Linq;
using CovidReader.Service;
using CovidReader.Service.Api;
using CovidReader.Service.Covid19;

namespace CovidReader.UseCases
{
    /// <summary>
    /// コンソールアプリケーション用コントローラー
    /// </summary>
    public class ConsoleAppController : AppController
    {
        //private ISettingRepository _settingRepository;
        private ChromeDriver _chrome;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="api"></param>
        /// <param name="covid19"></param>
        public ConsoleAppController(IApiService api, ICovid19Service covid19) : base(api, covid19)
        {
            //_settingRepository = new XmlSettingRepository(Constants.RootPath + @"assets\settings");
            //Task.WaitAll(InitializeAsync());

        }

        #region APIコマンド
        
        /// <summary>
        /// 自動実行処理
        /// XAMPPサーバーにChart表示用データとスクリプトファイルを保存し、サーバ起動＋ブラウザ起動
        /// </summary>
        /// <returns></returns>
        public async Task AutoRunAsync()
        {
            await ViewChartAsync();
        }

        /// <summary>
        /// スクレイピング処理（テスト用）
        /// </summary>
        /// <returns></returns>
        public async Task ScrapingAsync()
        {
            _chrome = new ChromeDriver();
            await Task.Run(() => 
            {
                _chrome.Url = "https://www.google.com/";
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
