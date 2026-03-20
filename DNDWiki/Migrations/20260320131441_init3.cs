using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNDWiki.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpellsId",
                table: "DndClasses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    School = table.Column<int>(type: "int", nullable: false),
                    HasVerbalComponent = table.Column<bool>(type: "bit", nullable: false),
                    HasSomaticComponent = table.Column<bool>(type: "bit", nullable: false),
                    HasMaterialComponent = table.Column<bool>(type: "bit", nullable: false),
                    MaterialList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spells_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DndClasses_SpellsId",
                table: "DndClasses",
                column: "SpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SourceId",
                table: "Spells",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DndClasses_Spells_SpellsId",
                table: "DndClasses",
                column: "SpellsId",
                principalTable: "Spells",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DndClasses_Spells_SpellsId",
                table: "DndClasses");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_DndClasses_SpellsId",
                table: "DndClasses");

            migrationBuilder.DropColumn(
                name: "SpellsId",
                table: "DndClasses");
        }
    }
}
