using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidReader.Covid.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CovidLineItems",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidLineItems", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Positives",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positives", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Recoveries",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recoveries", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Severes",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Severes", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "TestDetails",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    QuarantineNumber = table.Column<string>(nullable: true),
                    CareCenterNumber = table.Column<string>(nullable: true),
                    CivilCenterNumber = table.Column<string>(nullable: true),
                    CollegeNumber = table.Column<string>(nullable: true),
                    MedicalNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDetails", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Deathes",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deathes", x => x.Date);
                    table.ForeignKey(
                        name: "FK_Deathes_CovidLineItems_Date",
                        column: x => x.Date,
                        principalTable: "CovidLineItems",
                        principalColumn: "Date",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalizations",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalizations", x => x.Date);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_CovidLineItems_Date",
                        column: x => x.Date,
                        principalTable: "CovidLineItems",
                        principalColumn: "Date",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deathes");

            migrationBuilder.DropTable(
                name: "Hospitalizations");

            migrationBuilder.DropTable(
                name: "Positives");

            migrationBuilder.DropTable(
                name: "Recoveries");

            migrationBuilder.DropTable(
                name: "Severes");

            migrationBuilder.DropTable(
                name: "TestDetails");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "CovidLineItems");
        }
    }
}
