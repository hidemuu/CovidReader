using CovidReader.Models.Covid19.MHLW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW.Sql
{
    public class SqlRecoveryRepository : SqlCovid19RepositoryBase<Recovery>, IRecoveryRepository
    {

        public SqlRecoveryRepository(Covid19DbContext db) : base(db, db.Recoveries) { }

    }
}
