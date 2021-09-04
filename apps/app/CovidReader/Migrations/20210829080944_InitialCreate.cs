using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidReader.Migrations
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
                    BorderWidth = table.Column<int>(nullable: false)
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
                    TestNumber = table.Column<int>(nullable: false)
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
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Viruses");
        }
    }
}
