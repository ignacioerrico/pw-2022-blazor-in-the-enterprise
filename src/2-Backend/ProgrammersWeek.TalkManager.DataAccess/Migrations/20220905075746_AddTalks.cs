using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammersWeek.TalkManager.DataAccess.Migrations
{
    public partial class AddTalks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Talks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestAreaId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    SessionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talks_InterestAreas_InterestAreaId",
                        column: x => x.InterestAreaId,
                        principalTable: "InterestAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Talks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorTalk",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    TalksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorTalk", x => new { x.AuthorsId, x.TalksId });
                    table.ForeignKey(
                        name: "FK_AuthorTalk_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorTalk_Talks_TalksId",
                        column: x => x.TalksId,
                        principalTable: "Talks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorTalk_TalksId",
                table: "AuthorTalk",
                column: "TalksId");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_InterestAreaId",
                table: "Talks",
                column: "InterestAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_RegionId",
                table: "Talks",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorTalk");

            migrationBuilder.DropTable(
                name: "Talks");
        }
    }
}
