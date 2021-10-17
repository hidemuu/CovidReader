using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.UseCases
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAppController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task ImportCovid19Async();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task CovidToApiAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task ToChartItemAsync();
        
    }
}
