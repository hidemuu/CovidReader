using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidReader.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChartConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Calc = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ChartType = table.Column<string>(nullable: true),
                    BackgroundColor = table.Column<string>(nullable: true),
                    BorderColor = table.Column<string>(nullable: true),
                    BorderWidth = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Calc = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Infections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Calc = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    PrefName = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    DeathNumber = table.Column<int>(nullable: false),
                    CureNumber = table.Column<int>(nullable: false),
                    PatientNumber = table.Column<int>(nullable: false),
                    RecoveryNumber = table.Column<int>(nullable: false),
                    SevereNumber = table.Column<int>(nullable: false),
                    TestNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Calc = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    NationalTestNumber = table.Column<int>(nullable: false),
                    QuarantineTestNumber = table.Column<int>(nullable: false),
                    CareCenterTestNumber = table.Column<int>(nullable: false),
                    CivilCenterTestNumber = table.Column<int>(nullable: false),
                    CollegeTestNumber = table.Column<int>(nullable: false),
                    MedicalTestNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Calc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChartConfigs");

            migrationBuilder.DropTable(
                name: "ChartItems");

            migrationBuilder.DropTable(
                name: "Infections");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "LineItems");
        }
    }
}
