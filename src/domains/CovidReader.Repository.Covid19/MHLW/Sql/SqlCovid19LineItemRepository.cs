using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Sql
{
    public class SqlCovid19LineItemRepository : SqlCovid19RepositoryBase<Covid19LineItem>, ICovid19LineItemRepository
    {
        public SqlCovid19LineItemRepository(Covid19DbContext db) : base(db, db.CovidLineItems) { }
    }
}
