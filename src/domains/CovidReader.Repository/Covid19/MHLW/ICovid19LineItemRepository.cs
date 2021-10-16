using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW
{
    /// <summary>
    /// Covid19リポジトリ　各データ一覧（リレーション）
    /// </summary>
    public interface ICovid19LineItemRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Covid19LineItem>> GetAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<Covid19LineItem> GetAsync(string date);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task PostAsync(Covid19LineItem item);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task PostAsync(IEnumerable<Covid19LineItem> items);
    }
}
