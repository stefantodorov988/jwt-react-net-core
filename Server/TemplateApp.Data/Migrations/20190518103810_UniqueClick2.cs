using Microsoft.EntityFrameworkCore.Migrations;

namespace TemplateApp.Data.Migrations
{
    public partial class UniqueClick2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniqueClicks_IpAdresses_BlogId",
                table: "UniqueClicks");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "UniqueClicks",
                newName: "IpAdressId");

            migrationBuilder.RenameIndex(
                name: "IX_UniqueClicks_BlogId",
                table: "UniqueClicks",
                newName: "IX_UniqueClicks_IpAdressId");

            migrationBuilder.AddColumn<int>(
                name: "ClickCounter",
                table: "UniqueClicks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UniqueClicks_IpAdresses_IpAdressId",
                table: "UniqueClicks",
                column: "IpAdressId",
                principalTable: "IpAdresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniqueClicks_IpAdresses_IpAdressId",
                table: "UniqueClicks");

            migrationBuilder.DropColumn(
                name: "ClickCounter",
                table: "UniqueClicks");

            migrationBuilder.RenameColumn(
                name: "IpAdressId",
                table: "UniqueClicks",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_UniqueClicks_IpAdressId",
                table: "UniqueClicks",
                newName: "IX_UniqueClicks_BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_UniqueClicks_IpAdresses_BlogId",
                table: "UniqueClicks",
                column: "BlogId",
                principalTable: "IpAdresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
