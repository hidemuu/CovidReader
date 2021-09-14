using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlInfectionTotalRepository : SqlApiRepositoryBase<InfectionTotal>, IInfectionTotalRepository
    {
        public SqlInfectionTotalRepository(ApiDbContext db) : base(db, db.InfectionTotals) { }
    }
}
