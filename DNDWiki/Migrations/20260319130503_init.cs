using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNDWiki.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DndClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SavingThrowProficiencies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillProficiencies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolsProficiencies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaponsProficiencies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorProficiencies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DndClasses_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DndClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassFeature_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Name" },
                values: new object[] { "PHB24", "Players Handbook 2024" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeature_DndClassId",
                table: "ClassFeature",
                column: "DndClassId");

            migrationBuilder.CreateIndex(
                name: "IX_DndClasses_SourceId",
                table: "DndClasses",
                column: "SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassFeature");

            migrationBuilder.DropTable(
                name: "DndClasses");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
