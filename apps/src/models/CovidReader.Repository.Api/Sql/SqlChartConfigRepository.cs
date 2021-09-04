using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlChartConfigRepository : SqlApiRepositoryBase<ChartConfig>, IChartConfigRepository
    {
        public SqlChartConfigRepository(ApiDbContext db) : base(db, db.ChartConfigs) { }
    }
}
