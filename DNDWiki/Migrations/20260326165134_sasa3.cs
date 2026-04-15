using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNDWiki.Migrations
{
    /// <inheritdoc />
    public partial class sasa3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemType_TypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemType_WeaponTypeId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemType",
                table: "ItemType");

            migrationBuilder.RenameTable(
                name: "ItemType",
                newName: "ItemTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTypes",
                table: "ItemTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemTypes_TypeId",
                table: "Items",
                column: "TypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemTypes_WeaponTypeId",
                table: "Items",
                column: "WeaponTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemTypes_TypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemTypes_WeaponTypeId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTypes",
                table: "ItemTypes");

            migrationBuilder.RenameTable(
                name: "ItemTypes",
                newName: "ItemType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemType",
                table: "ItemType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemType_TypeId",
                table: "Items",
                column: "TypeId",
                principalTable: "ItemType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemType_WeaponTypeId",
                table: "Items",
                column: "WeaponTypeId",
                principalTable: "ItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
