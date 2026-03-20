using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DNDWiki.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmorProficiencies",
                table: "DndClasses");

            migrationBuilder.DropColumn(
                name: "SavingThrowProficiencies",
                table: "DndClasses");

            migrationBuilder.DropColumn(
                name: "SkillProficiencies",
                table: "DndClasses");

            migrationBuilder.DropColumn(
                name: "ToolsProficiencies",
                table: "DndClasses");

            migrationBuilder.DropColumn(
                name: "WeaponsProficiencies",
                table: "DndClasses");

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DndClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArmorTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DndClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmorTrainings_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToolTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DndClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolTypes_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DndClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponTypes_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    DndClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "DndClassId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Strength" },
                    { 2, null, "Dexterity" },
                    { 3, null, "Constitution" },
                    { 4, null, "Intelligence" },
                    { 5, null, "Wisdom" },
                    { 6, null, "Charisma" }
                });

            migrationBuilder.InsertData(
                table: "ArmorTrainings",
                columns: new[] { "Id", "DndClassId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Light" },
                    { 2, null, "Medium" },
                    { 3, null, "Heavy" },
                    { 4, null, "Shields" }
                });

            migrationBuilder.InsertData(
                table: "ToolTypes",
                columns: new[] { "Id", "DndClassId", "Name" },
                values: new object[,]
                {
                    { 1, null, "AlchemistSupplies" },
                    { 2, null, "BrewersSupplies" },
                    { 3, null, "CalligraphersSupplies" },
                    { 4, null, "CarpentersTools" },
                    { 5, null, "CartographersTools" },
                    { 6, null, "CobblersTools" },
                    { 7, null, "CooksUtensils" },
                    { 8, null, "GlassblowersTools" },
                    { 9, null, "JewelersTools" },
                    { 10, null, "LeatherworkersTools" },
                    { 11, null, "MasonsTools" },
                    { 12, null, "PaintersSupplies" },
                    { 13, null, "PottersTools" },
                    { 14, null, "SmithsTools" },
                    { 15, null, "TinkersTools" },
                    { 16, null, "WeaversTools" },
                    { 17, null, "WoodcarversTools" },
                    { 18, null, "Bagpipes" },
                    { 19, null, "Drum" },
                    { 20, null, "Dulcimer" },
                    { 21, null, "Flute" },
                    { 22, null, "Lute" },
                    { 23, null, "Lyre" },
                    { 24, null, "Horn" },
                    { 25, null, "PanFlute" },
                    { 26, null, "Shawm" },
                    { 27, null, "Viol" },
                    { 28, null, "DisguiseKit" },
                    { 29, null, "ForgeryKit" },
                    { 30, null, "HerbalismKit" },
                    { 31, null, "NavigatorsTools" },
                    { 32, null, "PoisonersKit" },
                    { 33, null, "ThievesTools" }
                });

            migrationBuilder.InsertData(
                table: "WeaponTypes",
                columns: new[] { "Id", "DndClassId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Simple" },
                    { 2, null, "Martial" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "AbilityId", "DndClassId", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "Athletics" },
                    { 2, 2, null, "Acrobatics" },
                    { 3, 2, null, "SleightOfHand" },
                    { 4, 2, null, "Stealth" },
                    { 5, 4, null, "Arcana" },
                    { 6, 4, null, "History" },
                    { 7, 4, null, "Investigation" },
                    { 8, 4, null, "Nature" },
                    { 9, 4, null, "Religion" },
                    { 10, 5, null, "AnimalHandling" },
                    { 11, 5, null, "Insight" },
                    { 12, 5, null, "Medicine" },
                    { 13, 5, null, "Perception" },
                    { 14, 5, null, "Survival" },
                    { 15, 6, null, "Deception" },
                    { 16, 6, null, "Intimidation" },
                    { 17, 6, null, "Performance" },
                    { 18, 6, null, "Persuasion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_DndClassId",
                table: "Abilities",
                column: "DndClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorTrainings_DndClassId",
                table: "ArmorTrainings",
                column: "DndClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AbilityId",
                table: "Skills",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_DndClassId",
                table: "Skills",
                column: "DndClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolTypes_DndClassId",
                table: "ToolTypes",
                column: "DndClassId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponTypes_DndClassId",
                table: "WeaponTypes",
                column: "DndClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmorTrainings");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "ToolTypes");

            migrationBuilder.DropTable(
                name: "WeaponTypes");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.AddColumn<string>(
                name: "ArmorProficiencies",
                table: "DndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SavingThrowProficiencies",
                table: "DndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkillProficiencies",
                table: "DndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToolsProficiencies",
                table: "DndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WeaponsProficiencies",
                table: "DndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
