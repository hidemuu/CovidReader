using CovidReader.Service;
using CovidReader.Repository;
using CovidReader.Repository.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CovidReader.Service.Api
{
    /// <summary>
    /// アプリケーションAPIアクセスサービス実装クラス
    /// </summary>
    public class ApiService : IApiService
    {
        private readonly IApiRepository _repository;
        private readonly IApiMapper _mapper;
        private static Process _process;
        /// <summary>
        /// チャート設定
        /// </summary>
        public IChartConfigService ChartConfig { get; }
        /// <summary>
        /// チャート表示データ
        /// </summary>
        public IChartItemService ChartItem { get; }
        /// <summary>
        /// 感染データ
        /// </summary>
        public IInfectionService Infection { get; }
        /// <summary>
        /// 検査データ
        /// </summary>
        public IInspectionService Inspection { get; }

        /// <summary>
        /// コンストラクタ
        /// アプリケーションAPIのリポジトリとマッパーを注入
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public ApiService(IApiRepository repository, IApiMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            ChartConfig = new ChartConfigService(repository.ChartConfigs);
            ChartItem = new ChartItemService(repository.ChartItems);
            Infection = new InfectionService(repository.Infections);
            Inspection = new InspectionService(repository.Inspections);
        }

        #region NoUse

        /// <summary>
        /// チャート表示データをXAMPPサーバにコピー
        /// </summary>
        public void CopyChartItem()
        {
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
        }
        /// <summary>
        /// XAMPPサーバー起動
        /// </summary>
        /// <returns></returns>
        public bool RunServerProcess()
        {
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
