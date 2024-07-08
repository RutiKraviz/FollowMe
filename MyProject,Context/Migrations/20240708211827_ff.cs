using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject_Context.Migrations
{
    /// <inheritdoc />
    public partial class ff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RouteId1",
                table: "Stations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stations_RouteId1",
                table: "Stations",
                column: "RouteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StationId",
                table: "Customers",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Stations_StationId",
                table: "Customers",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Routes_RouteId1",
                table: "Stations",
                column: "RouteId1",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Stations_StationId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Routes_RouteId1",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_RouteId1",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Customers_StationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RouteId1",
                table: "Stations");
        }
    }
}
