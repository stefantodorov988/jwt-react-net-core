using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TemplateApp.Data.Migrations
{
    public partial class UniqueClick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniqueClicks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    IpAdressIp = table.Column<int>(nullable: false),
                    BlogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueClicks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniqueClicks_IpAdresses_BlogId",
                        column: x => x.BlogId,
                        principalTable: "IpAdresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniqueClicks_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniqueClicks_BlogId",
                table: "UniqueClicks",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_UniqueClicks_PostId",
                table: "UniqueClicks",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniqueClicks");
        }
    }
}
