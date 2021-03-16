using Microsoft.EntityFrameworkCore.Migrations;

namespace MPGTracker2.Migrations
{
    public partial class ChangedNameLayout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Owner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Owner",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
