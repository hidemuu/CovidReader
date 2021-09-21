using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    /// <summary>
    /// アプリケーションAPIの共通リポジトリアクセス処理
    /// </summary>
    public interface IApiItemRepository<T>
    {
        /// <summary>
        /// すべてのデータを取得し指定クラスにデシリアライズ
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync();
        /// <summary>
        /// 指定日付のデータを取得し、指定クラスにデシリアライズ
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<T> GetAsync(string date);
        /// <summary>
        /// データをシリアライズしリポジトリに登録
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task PostAsync(T item);
        /// <summary>
        /// データリストをシリアライズしリポジトリに登録
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task PostAsync(IEnumerable<T> items);
        /// <summary>
        /// 指定日付のデータを削除
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task DeleteAsync(string date);
    }
}
