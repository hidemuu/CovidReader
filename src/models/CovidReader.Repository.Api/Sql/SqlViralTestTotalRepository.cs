using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlViralTestTotalRepository : SqlApiRepositoryBase<ViralTestTotal>, IViralTestTotalRepository
    {
        public SqlViralTestTotalRepository(ApiDbContext db) : base(db, db.ViralTestTotals) { }
    }
}
