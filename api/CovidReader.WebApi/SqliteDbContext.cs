using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidReader.Models.Covid19;
using CovidReader.Repository;
using CovidReader.Repository.Api.Sql;
using CovidReader.Repository.Covid19.MHLW.Sql;
using Microsoft.EntityFrameworkCore;

namespace CovidReader.WebApi
{
    public class SqliteDbContext : ApiDbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Urls.SqlLocalConnectionStringForSqlite);
            
        }

    }
}
