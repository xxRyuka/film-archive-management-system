using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC.Migrations
{
    /// <inheritdoc />
    public partial class GenreColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "genres",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "Color",
                value: "#fcad03");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "Color",
                value: "#fcad03");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "Color",
                value: "#fcad03");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "Color",
                value: "#fcad03");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "genres");
        }
    }
}
