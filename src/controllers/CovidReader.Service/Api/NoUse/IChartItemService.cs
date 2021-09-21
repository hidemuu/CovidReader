using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IChartItemService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task PostAsync(IEnumerable<ChartItem> items);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ChartItem>> GetAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="infections"></param>
        /// <returns></returns>
        Task CreateAsync(IEnumerable<Infection> infections);
    }
}
