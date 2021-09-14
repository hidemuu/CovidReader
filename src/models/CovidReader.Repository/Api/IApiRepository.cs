using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api
{
    public interface IApiRepository
    {
        IVirusRepository Viruses { get; }
        IInfectionRepository Infections { get; }
        IViralTestRepository ViralTests { get; }
        IInfectionTotalRepository InfectionTotals { get; }
        IViralTestTotalRepository ViralTestTotals { get; }
        IChartItemRepository ChartItems { get; }
        IChartConfigRepository ChartConfigs { get; }
    }
}
