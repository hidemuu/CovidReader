﻿// <auto-generated />
using CovidReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CovidReader.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20210829080944_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17");

            modelBuilder.Entity("CovidReader.Models.Api.ChartConfig", b =>
                {
                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("BackgroundColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("BorderColor")
                        .HasColumnType("TEXT");

                    b.Property<int>("BorderWidth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChartType")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Date");

                    b.ToTable("ChartConfigs");
                });

            modelBuilder.Entity("CovidReader.Models.Api.ChartItem", b =>
                {
                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Data")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Date");

                    b.ToTable("ChartItems");
                });

            modelBuilder.Entity("CovidReader.Models.Api.LineItem", b =>
                {
                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Date");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("CovidReader.Models.Api.Virus", b =>
                {
                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeathNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HospitalizationNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PositiveNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecoveryNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SevereNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TestNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Date");

                    b.ToTable("Viruses");
                });
#pragma warning restore 612, 618
        }
    }
}