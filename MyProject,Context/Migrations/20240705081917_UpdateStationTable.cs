using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject_Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations");

            migrationBuilder.AlterColumn<int>(
                name: "RouteId",
                table: "Stations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lan",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "Lan",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Stations");

            migrationBuilder.AlterColumn<int>(
                name: "RouteId",
                table: "Stations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }
    }
}
