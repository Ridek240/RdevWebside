using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DNDWiki.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DndClassToolType");

            migrationBuilder.DropTable(
                name: "ToolTypes");

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    Price_CopperPieces = table.Column<int>(type: "int", nullable: true),
                    Price_SilverPieces = table.Column<int>(type: "int", nullable: true),
                    Price_GoldPieces = table.Column<int>(type: "int", nullable: true),
                    Price_PlatiniumPieces = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    SourceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Item = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    WeaponTypeId = table.Column<int>(type: "int", nullable: true),
                    Damage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ItemType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ItemType_WeaponTypeId",
                        column: x => x.WeaponTypeId,
                        principalTable: "ItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DndClassItemTool",
                columns: table => new
                {
                    DndClassId = table.Column<int>(type: "int", nullable: false),
                    ToolsProficienciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndClassItemTool", x => new { x.DndClassId, x.ToolsProficienciesId });
                    table.ForeignKey(
                        name: "FK_DndClassItemTool_DndClasses_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DndClassItemTool_Items_ToolsProficienciesId",
                        column: x => x.ToolsProficienciesId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemToolId = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemFeatures_Items_ItemToolId",
                        column: x => x.ItemToolId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemFeatures_Items_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Item", "Name", "SourceId", "TypeId", "Weight" },
                values: new object[,]
                {
                    { 1, "", "Tool", "AlchemistSupplies", null, null, null },
                    { 2, "", "Tool", "BrewersSupplies", null, null, null },
                    { 3, "", "Tool", "CalligraphersSupplies", null, null, null },
                    { 4, "", "Tool", "CarpentersTools", null, null, null },
                    { 5, "", "Tool", "CartographersTools", null, null, null },
                    { 6, "", "Tool", "CobblersTools", null, null, null },
                    { 7, "", "Tool", "CooksUtensils", null, null, null },
                    { 8, "", "Tool", "GlassblowersTools", null, null, null },
                    { 9, "", "Tool", "JewelersTools", null, null, null },
                    { 10, "", "Tool", "LeatherworkersTools", null, null, null },
                    { 11, "", "Tool", "MasonsTools", null, null, null },
                    { 12, "", "Tool", "PaintersSupplies", null, null, null },
                    { 13, "", "Tool", "PottersTools", null, null, null },
                    { 14, "", "Tool", "SmithsTools", null, null, null },
                    { 15, "", "Tool", "TinkersTools", null, null, null },
                    { 16, "", "Tool", "WeaversTools", null, null, null },
                    { 17, "", "Tool", "WoodcarversTools", null, null, null },
                    { 18, "", "Tool", "Bagpipes", null, null, null },
                    { 19, "", "Tool", "Drum", null, null, null },
                    { 20, "", "Tool", "Dulcimer", null, null, null },
                    { 21, "", "Tool", "Flute", null, null, null },
                    { 22, "", "Tool", "Lute", null, null, null },
                    { 23, "", "Tool", "Lyre", null, null, null },
                    { 24, "", "Tool", "Horn", null, null, null },
                    { 25, "", "Tool", "PanFlute", null, null, null },
                    { 26, "", "Tool", "Shawm", null, null, null },
                    { 27, "", "Tool", "Viol", null, null, null },
                    { 28, "", "Tool", "DisguiseKit", null, null, null },
                    { 29, "", "Tool", "ForgeryKit", null, null, null },
                    { 30, "", "Tool", "HerbalismKit", null, null, null },
                    { 31, "", "Tool", "NavigatorsTools", null, null, null },
                    { 32, "", "Tool", "PoisonersKit", null, null, null },
                    { 33, "", "Tool", "ThievesTools", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DndClassItemTool_ToolsProficienciesId",
                table: "DndClassItemTool",
                column: "ToolsProficienciesId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemFeatures_ItemToolId",
                table: "ItemFeatures",
                column: "ItemToolId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemFeatures_WeaponId",
                table: "ItemFeatures",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SourceId",
                table: "Items",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TypeId",
                table: "Items",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_WeaponTypeId",
                table: "Items",
                column: "WeaponTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DndClassItemTool");

            migrationBuilder.DropTable(
                name: "ItemFeatures");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemType");

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

            migrationBuilder.CreateIndex(
                name: "IX_DndClassToolType_ToolsProficienciesId",
                table: "DndClassToolType",
                column: "ToolsProficienciesId");
        }
    }
}
