using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Core.Service
{
    public interface IApiService
    {
        IChartConfigService ChartConfig { get; }
        IChartItemService ChartItem { get; }
        IInfectionService Infection { get; }
        IInspectionService Inspection { get; }

        void CopyChartItem();

        bool RunServerProcess();

    }
}
