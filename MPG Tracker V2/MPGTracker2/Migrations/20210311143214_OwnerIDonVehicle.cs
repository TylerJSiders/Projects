using Microsoft.EntityFrameworkCore.Migrations;

namespace MPGTracker2.Migrations
{
    public partial class OwnerIDonVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Owner_OwnerID",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Owner_OwnerID",
                table: "Vehicle",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Owner_OwnerID",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Owner_OwnerID",
                table: "Vehicle",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
