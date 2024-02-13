using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.DietTrackApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class araogun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "MTName",
                value: "Ara Öğün");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "MTName",
                value: "Atıştımalık");
        }
    }
}
