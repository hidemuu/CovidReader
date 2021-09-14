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
                    Date = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ChartType = table.Column<string>(nullable: true),
                    BackgroundColor = table.Column<string>(nullable: true),
                    BorderColor = table.Column<string>(nullable: true),
                    BorderWidth = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartConfigs", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "ChartItems",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartItems", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Infections",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Infections", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "InfectionTotals",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_InfectionTotals", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "ViralTests",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_ViralTests", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "ViralTestTotals",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_ViralTestTotals", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Viruses",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DeathNumber = table.Column<int>(nullable: false),
                    HospitalizationNumber = table.Column<int>(nullable: false),
                    PositiveNumber = table.Column<int>(nullable: false),
                    RecoveryNumber = table.Column<int>(nullable: false),
                    SevereNumber = table.Column<int>(nullable: false),
                    TestNumber = table.Column<int>(nullable: false),
                    NationalTestNumber = table.Column<int>(nullable: false),
                    QuarantineTestNumber = table.Column<int>(nullable: false),
                    CareCenterTestNumber = table.Column<int>(nullable: false),
                    CivilCenterTestNumber = table.Column<int>(nullable: false),
                    CollegeTestNumber = table.Column<int>(nullable: false),
                    MedicalTestNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viruses", x => x.Date);
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
                name: "InfectionTotals");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "ViralTests");

            migrationBuilder.DropTable(
                name: "ViralTestTotals");

            migrationBuilder.DropTable(
                name: "Viruses");
        }
    }
}
