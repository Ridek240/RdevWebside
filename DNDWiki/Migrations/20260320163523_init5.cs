using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNDWiki.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CastingTime_Scale",
                table: "Spells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CastingTime_Value",
                table: "Spells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration_Scale",
                table: "Spells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration_Value",
                table: "Spells",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CastingTime_Scale",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "CastingTime_Value",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Duration_Scale",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Duration_Value",
                table: "Spells");
        }
    }
}
