using CovidReader.Models.Covid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlSevereRepository : SqlCovidRepositoryBase<Severe>, ISevereRepository
    {

        public SqlSevereRepository(CovidDbContext db) : base(db, db.Severes) { }

    }
}
