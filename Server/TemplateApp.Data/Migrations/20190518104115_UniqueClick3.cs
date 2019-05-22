using Microsoft.EntityFrameworkCore.Migrations;

namespace TemplateApp.Data.Migrations
{
    public partial class UniqueClick3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniqueClicks_IpAdresses_IpAdressId",
                table: "UniqueClicks");

            migrationBuilder.DropColumn(
                name: "IpAdressIp",
                table: "UniqueClicks");

            migrationBuilder.AlterColumn<int>(
                name: "IpAdressId",
                table: "UniqueClicks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UniqueClicks_IpAdresses_IpAdressId",
                table: "UniqueClicks",
                column: "IpAdressId",
                principalTable: "IpAdresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniqueClicks_IpAdresses_IpAdressId",
                table: "UniqueClicks");

            migrationBuilder.AlterColumn<int>(
                name: "IpAdressId",
                table: "UniqueClicks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IpAdressIp",
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
    }
}
