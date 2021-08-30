using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlVirusRepository : SqlApiRepositoryBase<Virus>, IVirusRepository
    {
        public SqlVirusRepository(ApiDbContext db) : base(db, db.Viruses) { }

    }
}
