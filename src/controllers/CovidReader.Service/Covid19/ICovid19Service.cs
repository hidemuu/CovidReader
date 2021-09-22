using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service.Covid19
{
    /// <summary>
    /// Covid19 APIアクセスサービス
    /// </summary>
    public interface ICovid19Service
    {
        /// <summary>
        /// マッパーデータをリポジトリに全て反映する
        /// </summary>
        /// <returns></returns>
        Task MapperToRepositoryAsync();
        /// <summary>
        /// リポジトリを更新（追加）
        /// </summary>
        /// <param name="deaths">死亡者数</param>
        /// <param name="hospitalizations">入院治療者数</param>
        /// <param name="positives">陽性者数</param>
        /// <param name="recoveries">治癒者数</param>
        /// <param name="severes">重傷者数</param>
        /// <param name="tests">検査件数</param>
        /// <param name="testDetails">検査詳細</param>
        /// <returns></returns>
        Task PostAsync(IEnumerable<Death> deaths, IEnumerable<Hospitalization> hospitalizations, IEnumerable<Positive> positives, IEnumerable<Recovery> recoveries, IEnumerable<Severe> severes, IEnumerable<Test> tests, IEnumerable<TestDetail> testDetails);
        /// <summary>
        /// データ取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync<T>() where T : Covid19DbObject;
    }
}
