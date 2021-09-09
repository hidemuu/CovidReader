using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Sql
{
    public class SqlCovidLineItemRepository : SqlCovidRepositoryBase<CovidLineItem>, ICovidLineItemRepository
    {
        public SqlCovidLineItemRepository(CovidDbContext db) : base(db, db.CovidLineItems) { }
    }
}
