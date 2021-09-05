using CovidReader.Models.Covid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlRecoveryRepository : SqlCovidRepositoryBase<Recovery>, IRecoveryRepository
    {

        public SqlRecoveryRepository(CovidDbContext db) : base(db, db.Recoveries) { }

    }
}
