using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidReader.Service.Api;
using CovidReader.Service.Covid19;

namespace CovidReader.UseCases.Controllers
{
    /// <summary>
    /// アプリケーション用コントローラー基本クラス
    /// </summary>
    public abstract class AppControllerBase : IAppController
    {
        /// <summary>
        /// アプリケーションAPI アクセスサービス
        /// </summary>
        protected IApiService api { get; }
        /// <summary>
        /// Covid19 APIアクセスサービス
        /// </summary>
        protected ICovid19Service covid19 { get; }
        
        /// <summary>
        /// アプリケーションAPI / Covid19 API アクセスサービスを取り込み、API全体の処理を構築
        /// </summary>
        /// <param name="api"></param>
        /// <param name="covid19"></param>
        public AppControllerBase(IApiService api, ICovid19Service covid19)
        {
            if (api == null) throw new ArgumentNullException("apiRepository");
            this.api = api;
            if (covid19 == null) throw new ArgumentNullException("covidRepository");
            this.covid19 = covid19;
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
            await covid19.MapperToRepositoryAsync();
        }

        /// <summary>
        /// Covid19 APIデータをアプリケーションAPIデータベーステーブルに反映
        /// </summary>
        /// <returns></returns>
        public async Task CovidToApiAsync()
        {
            var dates = await GetDatesAsync(await covid19.GetAsync<Covid19LineItem>());
            await api.Infection.CreateAsync(dates, await covid19.GetAsync<Death>(), await covid19.GetAsync<Hospitalization>(), await covid19.GetAsync<Positive>(), await covid19.GetAsync<Recovery>(), await covid19.GetAsync<Severe>(), await covid19.GetAsync<Test>());
            await api.Inspection.CreateAsync(dates, await covid19.GetAsync<TestDetail>());
            
        }

        /// <summary>
        /// アプリケーションAPIの感染データをChartItemテーブルに変換して格納 / ChartConfigテーブルデータを更新
        /// </summary>
        /// <returns></returns>
        public async Task ToChartItemAsync()
        {
            await api.ChartItem.CreateAsync(await api.Infection.GetAsync());
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
