using CovidReader.Core;
using CovidReader.Core.Service;
using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public class ApiController
    {
        
        public IApiService Api { get; }
        public ICovid19Service Covid19 { get; }

        public ApiController(IApiService api, ICovid19Service covid19)
        {
            if (api == null) throw new ArgumentNullException("apiRepository");
            Api = api;
            if (covid19 == null) throw new ArgumentNullException("covidRepository");
            Covid19 = covid19;
        }

        public async Task UpdateAsync()
        {
            await ImportAsync();
            await CovidToApiAsync();
            await ToChartItemAsync();
        }

        /// <summary>
        /// 外部データをリポジトリにインポート
        /// </summary>
        /// <returns></returns>
        public async Task ImportAsync()
        {
            Console.WriteLine("Importing...");
            await Covid19.MapperToRepositoryAsync();
        }

        

        /// <summary>
        /// CovidデータベースデータをApiデータベーステーブルに格納
        /// </summary>
        /// <returns></returns>
        public async Task CovidToApiAsync()
        {
            var dates = await GetDatesAsync(await Covid19.GetAsync<CovidLineItem>());
            await Api.Infection.CreateAsync(dates, await Covid19.GetAsync<Death>(), await Covid19.GetAsync<Hospitalization>(), await Covid19.GetAsync<Positive>(), await Covid19.GetAsync<Recovery>(), await Covid19.GetAsync<Severe>(), await Covid19.GetAsync<Test>());
            await Api.Inspection.CreateAsync(dates, await Covid19.GetAsync<TestDetail>());
            
        }

        /// <summary>
        /// VirusテーブルデータをChartItemテーブルに変換して格納 / ChartConfigテーブルデータを更新
        /// </summary>
        /// <returns></returns>
        public async Task ToChartItemAsync()
        {
            await Api.ChartItem.CreateAsync(await Api.Infection.GetAsync());
        }


        //private async Task InitializeAsync()
        //{
        //    var apiDb = (await _settingRepository.Configs.GetAsync("ApiDB")).Val;
        //    var covidDb = (await _settingRepository.Configs.GetAsync("CovidDB")).Val;
        //}

        private static async Task<IList<string>> GetDatesAsync(IEnumerable<CovidLineItem> covid19s)
        {
            //キーデータ取得
            var lineItems = covid19s.OrderBy(x => DateTime.Parse(x.Date));
            var dates = new List<string>();
            await Task.Run(() => 
            {
                foreach (var item in lineItems)
                {
                    dates.Add(item.Date);
                }
            });
            
            return dates;
        }
    }
}
