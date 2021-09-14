using CovidReader.Models.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlViralTestRepository : SqlApiRepositoryBase<ViralTest>, IViralTestRepository
    {
        public SqlViralTestRepository(ApiDbContext db) : base(db, db.ViralTests) { }
    }
}
