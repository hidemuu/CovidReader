using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlChartItemRepository : SqlApiRepositoryBase<ChartItem>, IChartItemRepository
    {
        public SqlChartItemRepository(ApiDbContext db) : base(db, db.ChartItems) { }
    }
}
