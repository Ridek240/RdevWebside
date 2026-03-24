using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DNDWiki.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmorTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorTrainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreatureSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTypes", x => x.Id);
                });

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
                name: "ToolTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "DndClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HitPointDie = table.Column<int>(type: "int", nullable: false),
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
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypicalSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypicalWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CastingTime_Value = table.Column<int>(type: "int", nullable: false),
                    CastingTime_Scale = table.Column<int>(type: "int", nullable: false),
                    Duration_Value = table.Column<int>(type: "int", nullable: false),
                    Duration_Scale = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "AbilityDndClass",
                columns: table => new
                {
                    DndClassId = table.Column<int>(type: "int", nullable: false),
                    SavingThrowProficienciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityDndClass", x => new { x.DndClassId, x.SavingThrowProficienciesId });
                    table.ForeignKey(
                        name: "FK_AbilityDndClass_Abilities_SavingThrowProficienciesId",
                        column: x => x.SavingThrowProficienciesId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityDndClass_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmorTrainingDndClass",
                columns: table => new
                {
                    ArmorProficienciesId = table.Column<int>(type: "int", nullable: false),
                    DndClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorTrainingDndClass", x => new { x.ArmorProficienciesId, x.DndClassId });
                    table.ForeignKey(
                        name: "FK_ArmorTrainingDndClass_ArmorTrainings_ArmorProficienciesId",
                        column: x => x.ArmorProficienciesId,
                        principalTable: "ArmorTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorTrainingDndClass_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "DndClassSkill",
                columns: table => new
                {
                    DndClassId = table.Column<int>(type: "int", nullable: false),
                    SkillProficienciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndClassSkill", x => new { x.DndClassId, x.SkillProficienciesId });
                    table.ForeignKey(
                        name: "FK_DndClassSkill_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DndClassSkill_Skills_SkillProficienciesId",
                        column: x => x.SkillProficienciesId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DndClassToolType",
                columns: table => new
                {
                    DndClassId = table.Column<int>(type: "int", nullable: false),
                    ToolsProficienciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndClassToolType", x => new { x.DndClassId, x.ToolsProficienciesId });
                    table.ForeignKey(
                        name: "FK_DndClassToolType_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DndClassToolType_ToolTypes_ToolsProficienciesId",
                        column: x => x.ToolsProficienciesId,
                        principalTable: "ToolTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DndClassWeaponType",
                columns: table => new
                {
                    DndClassId = table.Column<int>(type: "int", nullable: false),
                    WeaponsProficienciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndClassWeaponType", x => new { x.DndClassId, x.WeaponsProficienciesId });
                    table.ForeignKey(
                        name: "FK_DndClassWeaponType_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DndClassWeaponType_WeaponTypes_WeaponsProficienciesId",
                        column: x => x.WeaponsProficienciesId,
                        principalTable: "WeaponTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureSizeSpecies",
                columns: table => new
                {
                    CreatureSizesId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSizeSpecies", x => new { x.CreatureSizesId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_CreatureSizeSpecies_CreatureSizes_CreatureSizesId",
                        column: x => x.CreatureSizesId,
                        principalTable: "CreatureSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureSizeSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTraits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTraits", x => new { x.SpeciesId, x.Id });
                    table.ForeignKey(
                        name: "FK_CreatureTraits_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTypeSpecies",
                columns: table => new
                {
                    CreatureTypesId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTypeSpecies", x => new { x.CreatureTypesId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_CreatureTypeSpecies_CreatureTypes_CreatureTypesId",
                        column: x => x.CreatureTypesId,
                        principalTable: "CreatureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureTypeSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DndClassSpells",
                columns: table => new
                {
                    ClassesId = table.Column<int>(type: "int", nullable: false),
                    SpellsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndClassSpells", x => new { x.ClassesId, x.SpellsId });
                    table.ForeignKey(
                        name: "FK_DndClassSpells_DndClasses_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "DndClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DndClassSpells_Spells_SpellsId",
                        column: x => x.SpellsId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Strength" },
                    { 2, "Dexterity" },
                    { 3, "Constitution" },
                    { 4, "Intelligence" },
                    { 5, "Wisdom" },
                    { 6, "Charisma" }
                });

            migrationBuilder.InsertData(
                table: "ArmorTrainings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Light" },
                    { 2, "Medium" },
                    { 3, "Heavy" },
                    { 4, "Shields" }
                });

            migrationBuilder.InsertData(
                table: "CreatureSizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tiny" },
                    { 2, "Small" },
                    { 3, "Medium" },
                    { 4, "Large" },
                    { 5, "Huge" },
                    { 6, "Gargantuan" }
                });

            migrationBuilder.InsertData(
                table: "CreatureTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Aberration" },
                    { 2, "Beast" },
                    { 3, "Celestial" },
                    { 4, "Construct" },
                    { 5, "Dragon" },
                    { 6, "Elemental" },
                    { 7, "Fey" },
                    { 8, "Fiend" },
                    { 9, "Giant" },
                    { 10, "Humanoid" },
                    { 11, "Monstrosity" },
                    { 12, "Ooze" },
                    { 13, "Plant" },
                    { 14, "Undead" }
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Name" },
                values: new object[] { "PHB24", "Players Handbook 2024" });

            migrationBuilder.InsertData(
                table: "ToolTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AlchemistSupplies" },
                    { 2, "BrewersSupplies" },
                    { 3, "CalligraphersSupplies" },
                    { 4, "CarpentersTools" },
                    { 5, "CartographersTools" },
                    { 6, "CobblersTools" },
                    { 7, "CooksUtensils" },
                    { 8, "GlassblowersTools" },
                    { 9, "JewelersTools" },
                    { 10, "LeatherworkersTools" },
                    { 11, "MasonsTools" },
                    { 12, "PaintersSupplies" },
                    { 13, "PottersTools" },
                    { 14, "SmithsTools" },
                    { 15, "TinkersTools" },
                    { 16, "WeaversTools" },
                    { 17, "WoodcarversTools" },
                    { 18, "Bagpipes" },
                    { 19, "Drum" },
                    { 20, "Dulcimer" },
                    { 21, "Flute" },
                    { 22, "Lute" },
                    { 23, "Lyre" },
                    { 24, "Horn" },
                    { 25, "PanFlute" },
                    { 26, "Shawm" },
                    { 27, "Viol" },
                    { 28, "DisguiseKit" },
                    { 29, "ForgeryKit" },
                    { 30, "HerbalismKit" },
                    { 31, "NavigatorsTools" },
                    { 32, "PoisonersKit" },
                    { 33, "ThievesTools" }
                });

            migrationBuilder.InsertData(
                table: "WeaponTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Simple" },
                    { 2, "Martial" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "AbilityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Athletics" },
                    { 2, 2, "Acrobatics" },
                    { 3, 2, "SleightOfHand" },
                    { 4, 2, "Stealth" },
                    { 5, 4, "Arcana" },
                    { 6, 4, "History" },
                    { 7, 4, "Investigation" },
                    { 8, 4, "Nature" },
                    { 9, 4, "Religion" },
                    { 10, 5, "AnimalHandling" },
                    { 11, 5, "Insight" },
                    { 12, 5, "Medicine" },
                    { 13, 5, "Perception" },
                    { 14, 5, "Survival" },
                    { 15, 6, "Deception" },
                    { 16, 6, "Intimidation" },
                    { 17, 6, "Performance" },
                    { 18, 6, "Persuasion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityDndClass_SavingThrowProficienciesId",
                table: "AbilityDndClass",
                column: "SavingThrowProficienciesId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorTrainingDndClass_DndClassId",
                table: "ArmorTrainingDndClass",
                column: "DndClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeature_DndClassId",
                table: "ClassFeature",
                column: "DndClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureSizeSpecies_SpeciesId",
                table: "CreatureSizeSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTypeSpecies_SpeciesId",
                table: "CreatureTypeSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_DndClasses_SourceId",
                table: "DndClasses",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DndClassSkill_SkillProficienciesId",
                table: "DndClassSkill",
                column: "SkillProficienciesId");

            migrationBuilder.CreateIndex(
                name: "IX_DndClassSpells_SpellsId",
                table: "DndClassSpells",
                column: "SpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_DndClassToolType_ToolsProficienciesId",
                table: "DndClassToolType",
                column: "ToolsProficienciesId");

            migrationBuilder.CreateIndex(
                name: "IX_DndClassWeaponType_WeaponsProficienciesId",
                table: "DndClassWeaponType",
                column: "WeaponsProficienciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AbilityId",
                table: "Skills",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_SourceId",
                table: "Species",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SourceId",
                table: "Spells",
                column: "SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityDndClass");

            migrationBuilder.DropTable(
                name: "ArmorTrainingDndClass");

            migrationBuilder.DropTable(
                name: "ClassFeature");

            migrationBuilder.DropTable(
                name: "CreatureSizeSpecies");

            migrationBuilder.DropTable(
                name: "CreatureTraits");

            migrationBuilder.DropTable(
                name: "CreatureTypeSpecies");

            migrationBuilder.DropTable(
                name: "DndClassSkill");

            migrationBuilder.DropTable(
                name: "DndClassSpells");

            migrationBuilder.DropTable(
                name: "DndClassToolType");

            migrationBuilder.DropTable(
                name: "DndClassWeaponType");

            migrationBuilder.DropTable(
                name: "ArmorTrainings");

            migrationBuilder.DropTable(
                name: "CreatureSizes");

            migrationBuilder.DropTable(
                name: "CreatureTypes");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "ToolTypes");

            migrationBuilder.DropTable(
                name: "DndClasses");

            migrationBuilder.DropTable(
                name: "WeaponTypes");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
