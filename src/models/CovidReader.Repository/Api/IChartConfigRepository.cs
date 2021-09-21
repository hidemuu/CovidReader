using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    /// <summary>
    /// チャート設定データリポジトリ
    /// </summary>
    public interface IChartConfigRepository
    {
        /// <summary>
        /// すべてのデータを取得しデシリアライズ
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ChartConfig>> GetAsync();
        /// <summary>
        /// データをシリアライズしリポジトリに登録
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task PostAsync(IEnumerable<ChartConfig> items);
    }
}
