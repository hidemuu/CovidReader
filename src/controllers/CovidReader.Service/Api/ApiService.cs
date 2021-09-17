using CovidReader.Core.Service;
using CovidReader.Core.Services;
using CovidReader.Repository;
using CovidReader.Repository.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CovidReader.Service
{
    public class ApiService : IApiService
    {
        private readonly IApiRepository _repository;
        private readonly IApiRepository _mapper;
        private static Process _process;

        public IChartConfigService ChartConfig { get; }

        public IChartItemService ChartItem { get; }

        public IInfectionService Infection { get; }

        public IInspectionService Inspection { get; }

        public ApiService(IApiRepository repository, IApiRepository mapper)
        {
            _repository = repository;
            _mapper = mapper;
            ChartConfig = new ChartConfigService(repository.ChartConfigs);
            ChartItem = new ChartItemService(repository.ChartItems);
            Infection = new InfectionService(repository.Infections);
            Inspection = new InspectionService(repository.Inspections);
        }

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

    }
}
