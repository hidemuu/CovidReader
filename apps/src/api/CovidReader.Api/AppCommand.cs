using CovidReader.Controllers;
using CovidReader.Models;
using CovidReader.Repository;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid;
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
    public class AppCommand : CommandBase
    {
        private AppController _controller;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiType"></param>
        /// <param name="covidType"></param>
        public AppCommand(string apiType, string covidType)
        {
            IApiRepository api;
            switch (apiType)
            {
                case "sql": api = ApiRepositoryUseCase.UseSqlite(); break;
                case "csv": api = ApiRepositoryUseCase.UseCsv(); break;
                case "json": api = ApiRepositoryUseCase.UseJson(); break;
                default: api = ApiRepositoryUseCase.UseSqlite(); break;
            }
            ICovidRepository covid;
            switch (covidType)
            {
                case "sql": covid = CovidRepositoryUseCase.UseSqlite(); break;
                case "rest": covid = CovidRepositoryUseCase.UseRest(); break;
                case "csv": covid = CovidRepositoryUseCase.UseCsv(); break;
                case "json": covid = CovidRepositoryUseCase.UseJson(); break;
                default: covid = CovidRepositoryUseCase.UseSqlite(); break;
            }

            _controller = new AppController(api, covid);
            
            _handlers = new Dictionary<string, CommandHandler>
            {
                {"update", UpdateAsync },
                {"autorun", AutoRunAsync },
                {"scrap", ScrapingAsync },
                {"viewchart", ViewChartAsync },
                {"get", GetAsync },
                
            };
        }

        private async Task<string> UpdateAsync(IEnumerable<string> parameters)
        {
            await _controller.UpdateAsync();
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

        private async Task<string> GetAsync(IEnumerable<string> parameters)
        {
            switch ((DbCategoryKeys)Enum.Parse(typeof(DbCategoryKeys), parameters.ToArray()[0]))
            {
                case DbCategoryKeys.Api:
                    await _controller.GetApiAsync();
                    break;
                case DbCategoryKeys.Covid:
                    await _controller.GetCovidAsync(parameters.ToArray()[1]);
                    break;
            }          
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
                "update    : データ取得" + newline +
                "autorun   : チャート表示";
        }

        

    }
}
