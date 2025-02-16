using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFC.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "ActorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Leonardo", "DiCaprio" },
                    { 2, "Brad", "Pitt" }
                });

            migrationBuilder.InsertData(
                table: "directors",
                columns: new[] { "DirectorId", "Bio", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, null, "Christopher", "Nolan" },
                    { 2, null, "Sena", "Kuş" }
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Action" },
                    { 2, null, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "Description", "DirectorId", "MovieTitle", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Sci-Fi Thriller", 1, "Inception", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Psychological Drama", 2, "Fight Club", new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 2);
        }
    }
}
