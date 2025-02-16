using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC.Migrations
{
    /// <inheritdoc />
    public partial class imgFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieImg",
                table: "movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActorImg",
                table: "directors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActorImg",
                table: "actors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 1,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 2,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 3,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 4,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 5,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 1,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 2,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 3,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 4,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 5,
                column: "ActorImg",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "MovieImg",
                value: "movie.jpg");

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "MovieImg",
                value: "movie.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieImg",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "ActorImg",
                table: "directors");

            migrationBuilder.DropColumn(
                name: "ActorImg",
                table: "actors");
        }
    }
}
