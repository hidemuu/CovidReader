using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    /// <summary>
    /// チャート表示項目リポジトリ
    /// </summary>
    public interface IChartItemRepository : IApiItemRepository<ChartItem>
    {
        
    }
}
