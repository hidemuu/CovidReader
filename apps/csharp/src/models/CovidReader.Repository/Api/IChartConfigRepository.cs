using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    public interface IChartConfigRepository
    {
        Task<IEnumerable<ChartConfig>> GetAsync();
        Task PostAsync(IEnumerable<ChartConfig> items);
    }
}
