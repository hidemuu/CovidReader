using CovidReader.Models.Covid19.MHLW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Sql
{
    public class Covid19DbContext : DbContext
    {

        public Covid19DbContext() { }

        public Covid19DbContext(DbContextOptions<Covid19DbContext> options) : base(options)
        {

        }

        public DbSet<Death> Deathes { get; set; }

        public DbSet<Hospitalization> Hospitalizations { get; set; }

        public DbSet<Positive> Positives { get; set; }

        public DbSet<Recovery> Recoveries { get; set; }

        public DbSet<Severe> Severes { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<TestDetail> TestDetails { get; set; }

        public DbSet<CovidLineItem> CovidLineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 複合キーの場合、以下のように指定してやる。
            // ない場合「Entity type 'Item' has composite primary key defined with data annotations. To set composite primary key, use fluent API.」と表示される
            //modelBuilder.Entity<Item>()
            //     .HasKey(c => new { c.Id, c.PointNo });
            // エリアと店舗情報で1:nの関係を作成
            //modelBuilder.Entity<MShop>()
            //    .HasOne(s => s.Area)
            //    .WithMany(a => a.Shops);

            modelBuilder.Entity<CovidLineItem>()
            .HasOne(b => b.Death)
            .WithOne()
            .HasForeignKey<Death>(b => b.Date);

            modelBuilder.Entity<CovidLineItem>()
            .HasOne(b => b.Hospitalization)
            .WithOne()
            .HasForeignKey<Hospitalization>(b => b.Date);
        }
    }
}
