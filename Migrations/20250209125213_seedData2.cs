using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFC.Migrations
{
    /// <inheritdoc />
    public partial class seedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "ActorId", "FirstName", "LastName" },
                values: new object[] { 3, "Samet", "Yarrakoğlu" });

            migrationBuilder.InsertData(
                table: "directors",
                columns: new[] { "DirectorId", "Bio", "FirstName", "LastName" },
                values: new object[] { 3, null, "Hamza", "Demir" });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "Description", "Name" },
                values: new object[,]
                {
                    { 3, null, "Sci-Fi" },
                    { 4, null, "Romance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 4);
        }
    }
}
