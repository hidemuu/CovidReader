using CovidReader.Models.Covid19.MHLW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW.Sql
{
    public class SqlTestDetailRepository : SqlCovidRepositoryBase<TestDetail>, ITestDetailRepository
    {

        public SqlTestDetailRepository(CovidDbContext db) : base(db, db.TestDetails) { }

    }
}
