using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service.Api
{
    /// <summary>
    /// 検査データアクセスサービス
    /// </summary>
    public interface IInspectionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task PostAsync(IEnumerable<Inspection> items);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Inspection>> GetAsync();
        /// <summary>
        /// Covid19 APIから取得した各検査データで、アプリケーションデータベースを生成（全更新）
        /// </summary>
        /// <param name="dates"></param>
        /// <param name="testDetails"></param>
        /// <returns></returns>
        Task CreateAsync(IList<string> dates, IEnumerable<TestDetail> testDetails);
        
    }
}
