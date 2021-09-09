using CovidReader.Models.Api;
using CovidReader.Models.Covid19;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext() { }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Virus> Viruses { get; set; }
        public DbSet<ChartItem> ChartItems { get; set; }
        public DbSet<ChartConfig> ChartConfigs { get; set; }

        public DbSet<LineItem> LineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
