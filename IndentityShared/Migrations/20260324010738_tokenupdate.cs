using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndentityShared.Migrations
{
    /// <inheritdoc />
    public partial class tokenupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InviteToken",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "InviteTokenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InviteTokenId",
                table: "AspNetUsers",
                column: "InviteTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_InviteTokens_InviteTokenId",
                table: "AspNetUsers",
                column: "InviteTokenId",
                principalTable: "InviteTokens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_InviteTokens_InviteTokenId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InviteTokenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InviteTokenId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "InviteToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
