using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidReader.Service.Api;
using CovidReader.Service.Covid19;

namespace CovidReader.Controllers
{
    /// <summary>
    /// アプリケーション用コントローラー基本クラス
    /// </summary>
    public class AppController : IAppController
    {
        /// <summary>
        /// アプリケーションAPI アクセスサービス
        /// </summary>
        public IApiService Api { get; }
        /// <summary>
        /// Covid19 APIアクセスサービス
        /// </summary>
        public ICovid19Service Covid19 { get; }
        
        /// <summary>
        /// アプリケーションAPI / Covid19 API アクセスサービスを取り込み、API全体の処理を構築
        /// </summary>
        /// <param name="api"></param>
        /// <param name="covid19"></param>
        public AppController(IApiService api, ICovid19Service covid19)
        {
            if (api == null) throw new ArgumentNullException("apiRepository");
            Api = api;
            if (covid19 == null) throw new ArgumentNullException("covidRepository");
            Covid19 = covid19;
        }
        /// <summary>
        /// アップデート処理
        /// Covid19 APIデータをインポート → アプリケーションAPIに反映
        /// </summary>
        /// <returns></returns>
        public async Task UpdateAsync()
        {
            await ImportCovid19Async();
            await CovidToApiAsync();
            //await ToChartItemAsync();
        }

        /// <summary>
        /// Covid19データをインポート
        /// </summary>
        /// <returns></returns>
        public async Task ImportCovid19Async()
        {
            Console.WriteLine("Importing Covid19...");
            await Covid19.MapperToRepositoryAsync();
        }

        /// <summary>
        /// Covid19 APIデータをアプリケーションAPIデータベーステーブルに反映
        /// </summary>
        /// <returns></returns>
        public async Task CovidToApiAsync()
        {
            var dates = await GetDatesAsync(await Covid19.GetAsync<Covid19LineItem>());
            await Api.Infection.CreateAsync(dates, await Covid19.GetAsync<Death>(), await Covid19.GetAsync<Hospitalization>(), await Covid19.GetAsync<Positive>(), await Covid19.GetAsync<Recovery>(), await Covid19.GetAsync<Severe>(), await Covid19.GetAsync<Test>());
            await Api.Inspection.CreateAsync(dates, await Covid19.GetAsync<TestDetail>());
            
        }

        /// <summary>
        /// アプリケーションAPIの感染データをChartItemテーブルに変換して格納 / ChartConfigテーブルデータを更新
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

        private static async Task<IList<string>> GetDatesAsync(IEnumerable<Covid19LineItem> covid19s)
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
