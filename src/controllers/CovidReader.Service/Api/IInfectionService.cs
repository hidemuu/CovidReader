using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service.Api
{
    /// <summary>
    /// 感染データアクセスサービス
    /// </summary>
    public interface IInfectionService
    {
        /// <summary>
        /// 感染データをシリアライズして更新・追加
        /// </summary>
        /// <param name="items">更新・追加データ</param>
        /// <returns></returns>
        Task PostAsync(IEnumerable<Infection> items);
        /// <summary>
        /// 感染データを取得してデシリアライズ
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Infection>> GetAsync();
        /// <summary>
        /// Covid19 APIから取得した各感染データで、アプリケーションデータベースを生成（全更新）
        /// </summary>
        /// <param name="dates">日付</param>
        /// <param name="deaths">死亡者数</param>
        /// <param name="hospitalizations">入院治療者数</param>
        /// <param name="positives">陽性者数</param>
        /// <param name="recoveries">治癒者数</param>
        /// <param name="severes">重傷者数</param>
        /// <param name="tests">検査件数</param>
        /// <returns></returns>
        Task CreateAsync(IList<string> dates, IEnumerable<Death> deaths, IEnumerable<Hospitalization> hospitalizations, IEnumerable<Positive> positives, IEnumerable<Recovery> recoveries, IEnumerable<Severe> severes, IEnumerable<Test> tests);

        
    }
}
