using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DNDWiki.Migrations
{
    /// <inheritdoc />
    public partial class sasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ItemType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Simple Weapon" },
                    { 2, "Martial Weapon" },
                    { 3, "Light Armor" },
                    { 4, "Medium Armor" },
                    { 5, "Heavy Armor" },
                    { 6, "Shield" },
                    { 7, "Ammunition" },
                    { 8, "Tool" },
                    { 9, "Artisan Tool" },
                    { 10, "Gaming Set" },
                    { 11, "Musical Instrument" },
                    { 12, "Adventuring Gear" },
                    { 13, "Pack" },
                    { 14, "Container" },
                    { 15, "Gemstone" },
                    { 16, "Holy Symbol" },
                    { 17, "Arcane Focus" },
                    { 18, "Druidic Focus" },
                    { 19, "Poison" },
                    { 20, "Potion" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Alchemist Supplies");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Brewers Supplies");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Calligraphers Supplies");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Carpenters Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Cartographers Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Cobblers Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Cooks Utensils");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Glassblowers Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Jewelers Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Leatherworkers Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Masons Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Painters Supplies");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Potters Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Smiths Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Tinkers Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Weavers Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Woodcarvers Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Disguise Kit");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Forgery Kit");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Herbalism Kit");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Navigators Tools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Poisoners Kit");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Thieves Tools");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Item", "Name", "SourceId", "TypeId", "Weight" },
                values: new object[,]
                {
                    { 34, "", "Tool", "Dice Set", null, null, null },
                    { 35, "", "Tool", "Dragonchess Set", null, null, null },
                    { 36, "", "Tool", "Playing Card Set", null, null, null },
                    { 37, "", "Tool", "Three Dragon Ante Set", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "AlchemistSupplies");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "BrewersSupplies");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "CalligraphersSupplies");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "CarpentersTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "CartographersTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "CobblersTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "CooksUtensils");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "GlassblowersTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "JewelersTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "LeatherworkersTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "MasonsTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "PaintersSupplies");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "PottersTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "SmithsTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "TinkersTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "WeaversTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "WoodcarversTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "DisguiseKit");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "ForgeryKit");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "HerbalismKit");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "NavigatorsTools");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "PoisonersKit");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "ThievesTools");
        }
    }
}
