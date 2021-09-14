﻿// <auto-generated />
using CovidReader.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CovidReader.Web.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    partial class SqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Category")
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

            modelBuilder.Entity("CovidReader.Models.Api.Infection", b =>
                {
                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CureNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeathNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumberType")
                        .HasColumnType("TEXT");

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

                    b.HasKey("Date");

                    b.ToTable("Infections");
                });

            modelBuilder.Entity("CovidReader.Models.Api.InfectionTotal", b =>
                {
                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CureNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeathNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
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

                    b.HasKey("Date");

                    b.ToTable("InfectionTotals");
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

            modelBuilder.Entity("CovidReader.Models.Api.ViralTest", b =>
                {
                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("CareCenterTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CivilCenterTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CollegeTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedicalTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NationalTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuarantineTestNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Date");

                    b.ToTable("ViralTests");
                });

            modelBuilder.Entity("CovidReader.Models.Api.ViralTestTotal", b =>
                {
                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("CareCenterTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CivilCenterTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CollegeTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedicalTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NationalTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuarantineTestNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Date");

                    b.ToTable("ViralTestTotals");
                });

            modelBuilder.Entity("CovidReader.Models.Api.Virus", b =>
                {
                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("CareCenterTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CivilCenterTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CollegeTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeathNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HospitalizationNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedicalTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NationalTestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositiveNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuarantineTestNumber")
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
