using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service.Api
{
    /// <summary>
    /// 
    /// </summary>
    public interface IChartConfigService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task PostAsync(IEnumerable<ChartConfig> items);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ChartConfig>> GetAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task CreateAsync();
    }
}
