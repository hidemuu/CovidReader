using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Service
{
    public interface IChartConfigService
    {
        Task PostAsync(IEnumerable<ChartConfig> items);
        Task<IEnumerable<ChartConfig>> GetAsync();
        Task CreateAsync();
    }
}
