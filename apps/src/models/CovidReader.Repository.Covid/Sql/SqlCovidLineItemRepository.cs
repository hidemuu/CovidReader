using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlCovidLineItemRepository : SqlCovidRepositoryBase<CovidLineItem>, ICovidLineItemRepository
    {
        public SqlCovidLineItemRepository(CovidDbContext db) : base(db, db.CovidLineItems) { }
    }
}
