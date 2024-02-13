using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BA.DietTrackApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MealTypes",
                columns: new[] { "Id", "MTName" },
                values: new object[,]
                {
                    { 1, "Kahvaltı" },
                    { 2, "Öğle Yemeği" },
                    { 3, "Aşkam Yemeği" },
                    { 4, "Atıştımalık" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
