using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpboolflix.Migrations
{
    /// <inheritdoc />
    public partial class Series4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Seasons_SeasonId",
                table: "Media");

            migrationBuilder.AlterColumn<int>(
                name: "SeasonId",
                table: "Media",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Media",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Seasons_SeasonId",
                table: "Media",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Seasons_SeasonId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Media");

            migrationBuilder.AlterColumn<int>(
                name: "SeasonId",
                table: "Media",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Seasons_SeasonId",
                table: "Media",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id");
        }
    }
}
