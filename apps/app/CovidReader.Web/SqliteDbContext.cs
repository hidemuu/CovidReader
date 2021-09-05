using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidReader.Models.Covid;
using CovidReader.Repository;
using CovidReader.Repository.Api.Sql;
using CovidReader.Repository.Covid.Sql;
using Microsoft.EntityFrameworkCore;

namespace CovidReader.Web
{
    public class SqliteDbContext : ApiDbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = new SqliteConnectionStringBuilder { DataSource = Constants.RootPath + @"\assets\covid\" + @"covid.db" }.ToString();
            optionsBuilder.UseSqlite("Data Source=" + Urls.SqlLocalConnectionString);
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // 複合キーの場合、以下のように指定してやる。
        //    // ない場合「Entity type 'Item' has composite primary key defined with data annotations. To set composite primary key, use fluent API.」と表示される
        //    //modelBuilder.Entity<Item>().HasKey(c => new { c.Id, c.PointNo });
        //}

        

    }
}
