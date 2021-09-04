using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api
{
    public interface IApiRepository
    {
        IVirusRepository Viruses { get; }
        IChartItemRepository ChartItems { get; }
        IChartConfigRepository ChartConfigs { get; }
    }
}
