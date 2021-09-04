using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Rest
{
    public class RestChartItemRepository : RestApiRepositoryBase<ChartItem>, IChartItemRepository
    {
        public RestChartItemRepository(string url, string key) : base(url, key, "chart_item") { }
    }
}
