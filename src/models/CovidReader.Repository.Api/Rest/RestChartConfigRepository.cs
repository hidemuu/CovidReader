using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Rest
{
    public class RestChartConfigRepository : RestApiRepositoryBase<ChartConfig>, IChartConfigRepository
    {
        public RestChartConfigRepository(string url, string key) : base(url, key, "chart_config") { }

    }
}
