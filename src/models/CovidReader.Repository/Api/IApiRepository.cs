using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api
{
    public interface IApiRepository
    {
        IInfectionRepository Infections { get; }
        IInspectionRepository Inspections { get; }
        IChartItemRepository ChartItems { get; }
        IChartConfigRepository ChartConfigs { get; }
    }
}
