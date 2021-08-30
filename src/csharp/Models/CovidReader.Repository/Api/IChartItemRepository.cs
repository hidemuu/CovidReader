using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    public interface IChartItemRepository
    {
        Task<IEnumerable<ChartItem>> GetAsync();
        Task<ChartItem> GetAsync(string date);
        Task PostAsync(ChartItem item);
        Task PostAsync(IEnumerable<ChartItem> items);
        Task DeleteAsync(string date);
    }
}
