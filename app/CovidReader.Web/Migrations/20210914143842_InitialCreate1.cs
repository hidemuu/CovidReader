using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidReader.Web.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumberType",
                table: "Infections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberType",
                table: "Infections");
        }
    }
}
