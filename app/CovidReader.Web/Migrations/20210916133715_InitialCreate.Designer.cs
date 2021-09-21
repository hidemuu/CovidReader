﻿// <auto-generated />
using System;
using CovidReader.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CovidReader.Web.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20210916133715_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17");

            modelBuilder.Entity("CovidReader.Models.Api.ChartConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BackgroundColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("BorderColor")
                        .HasColumnType("TEXT");

                    b.Property<int>("BorderWidth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Calc")
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChartType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ChartConfigs");
                });

            modelBuilder.Entity("CovidReader.Models.Api.ChartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Calc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ChartItems");
                });

            modelBuilder.Entity("CovidReader.Models.Api.Infection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Calc")
                        .HasColumnType("TEXT");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CureNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DeathNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PatientNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrefName")
                        .HasColumnType("TEXT");

                    b.Property<int>("RecoveryNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SevereNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TestNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Infections");
                });

            modelBuilder.Entity("CovidReader.Models.Api.Inspection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Calc")
                        .HasColumnType("TEXT");

                    b.Property<int>("CareCenterTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CivilCenterTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CollegeTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedicalTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NationalTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuarantineTestNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Inspections");
                });

            modelBuilder.Entity("CovidReader.Models.Api.LineItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Calc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("LineItems");
                });
#pragma warning restore 612, 618
        }
    }
}