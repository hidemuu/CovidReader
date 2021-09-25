using CovidReader.Models.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlInfectionRepository : SqlApiDailyRepositoryBase<Infection>, IInfectionRepository
    {
        public SqlInfectionRepository(ApiDbContext db) : base(db, db.Infections) { }
    }
}
