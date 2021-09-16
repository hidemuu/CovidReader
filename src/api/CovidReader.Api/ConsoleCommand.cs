﻿using CovidReader.Controllers;
using CovidReader.Controllers.UseCases;
using CovidReader.Models;
using CovidReader.Repository;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsoleCommand : CommandBase
    {
        private ConsoleController _controller;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiType"></param>
        /// <param name="covidType"></param>
        public ConsoleCommand(string apiType, string covidType)
        {
            IApiRepository api;
            switch (apiType)
            {
                case "sql": api = ApiRepositoryUseCase.UseSqlite(); break;
                case "csv": api = ApiRepositoryUseCase.UseCsv(); break;
                case "json": api = ApiRepositoryUseCase.UseJson(); break;
                default: api = ApiRepositoryUseCase.UseSqlite(); break;
            }
            ICovid19Repository covid;
            switch (covidType)
            {
                case "sql": covid = CovidRepositoryUseCase.UseSqlite(); break;
                case "rest": covid = CovidRepositoryUseCase.UseRest(); break;
                case "csv": covid = CovidRepositoryUseCase.UseCsv(); break;
                case "json": covid = CovidRepositoryUseCase.UseJson(); break;
                case "inmemory": covid = CovidRepositoryUseCase.UseInMemory(); break;
                default: covid = CovidRepositoryUseCase.UseSqlite(); break;
            }

            _controller = new ConsoleController(api, covid);
            
            _handlers = new Dictionary<string, CommandHandler>
            {
                {"get", GetAsync },
                {"import", ImportAsync },
                {"update", UpdateAsync },
                {"getchart", GetChartAsync },
                {"autorun", AutoRunAsync },
                {"scrap", ScrapingAsync },
                {"viewchart", ViewChartAsync },
                
            };
        }

        private async Task<string> ImportAsync(IEnumerable<string> parameters)
        {
            await _controller.ImportAsync();
            return "";
        }

        private async Task<string> UpdateAsync(IEnumerable<string> parameters)
        {
            await _controller.UpdateAsync();
            return "";
        }

        private async Task<string> GetAsync(IEnumerable<string> parameters)
        {
            await _controller.GetAsync();
            return "";
        }

        private async Task<string> AutoRunAsync(IEnumerable<string> parameters)
        {
            await _controller.AutoRunAsync();
            return "";
        }

        private async Task<string> ScrapingAsync(IEnumerable<string> parameters)
        {
            await _controller.ScrapingAsync();
            return "";
        }

        private async Task<string> GetChartAsync(IEnumerable<string> parameters)
        {
            await _controller.GetChartItemAsync();
            return "";
        }

        private async Task<string> ViewChartAsync(IEnumerable<string> parameters)
        {
            var result = await Task.Run(() => _controller.ViewChartAsync());
            return result.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string Help()
        {
            var newline = Formats.NewLine;
            return
                base.Help() + newline +
                "import    : Covid Open APIデータインポート" + newline +
                "update    : APIデータ更新" + newline +
                "getchart  : チャートデータ更新" + newline +
                "viewchart : チャート表示" + newline +
                "autorun   : チャート表示";
        }

        

    }
}
