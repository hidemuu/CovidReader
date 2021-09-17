using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Service
{
    public interface IChartItemService
    {
        Task PostAsync(IEnumerable<ChartItem> items);
        Task<IEnumerable<ChartItem>> GetAsync();
        Task CreateAsync(IEnumerable<Infection> infections);
    }
}
