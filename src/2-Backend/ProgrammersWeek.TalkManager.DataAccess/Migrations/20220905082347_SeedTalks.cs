using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammersWeek.TalkManager.DataAccess.Migrations
{
    public partial class SeedTalks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorTalk");

            migrationBuilder.CreateTable(
                name: "TalkAuthor",
                columns: table => new
                {
                    TalkId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalkAuthor", x => new { x.TalkId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_TalkAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TalkAuthor_Talks_TalkId",
                        column: x => x.TalkId,
                        principalTable: "Talks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Talks",
                columns: new[] { "Id", "DateTimeUtc", "Description", "InterestAreaId", "RegionId", "SessionType", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), "The world often looks at DevOps as nothing more than a culture shift. Not a role and not a skill. Let's look at an alternative view.", 1, 1, 0, "Cultural shift; DevOps is not" },
                    { 2, new DateTime(2022, 9, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), "This presentation will cover the main principles and best practices of Continuous Delivery. It will reveal how properly implemented Continuous Delivery programs can reduce distractions and repetitive work, and help to keep the focus on business problem solving and faster product delivery.", 1, 3, 0, "Continuous Delivery: Work Less, Do More" },
                    { 3, new DateTime(2022, 9, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "Unikernels technology: From basic to advanced. A brief history of its origins, an overview of the variations that appear over time, and the evolution of the technology using demonstrations.", 1, 3, 0, "Unikernels - Challenging Docker" },
                    { 4, new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), ".NET MAUI is a cross-platform framework for creating native mobile and desktop apps with .NET. It unifies Android, iOS, macOS, and Windows APIs into a single API that allows a write-once run-anywhere developer experience, while additionally providing deep access to every aspect of each native platform.", 2, 1, 0, "Building Blazor Hybrid Apps on .NET MAUI" },
                    { 5, new DateTime(2022, 9, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), "Microsoft introduced built-in .NET platform level support for feature flags starting in .NET Core 3.0 in 2019. Feature flags, also known as feature toggles, are a powerful tool in modern application development, continuous integration, and DevOps, enabling many valuable scenarios such as separating deployment from release (\"dark launch\", etc.), targeting functionality to a select group of users, conducting A/B tests, shielding one team's work in progress from other teams, and others.", 2, 1, 0, "Using Feature Flags to Improve Development and Delivery" },
                    { 6, new DateTime(2022, 9, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), "Minimal APIs enable quick service development with less boilerplate code if we combine it with popular libraries like MediatR and patterns like CQRS. Audience will learn how they can take advantage of it in their daily work and how this can help teams create microservices in a quicker, more scalable and testable way.", 2, 2, 0, "Minimal API with MediatR and CQRS" },
                    { 7, new DateTime(2022, 9, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "This talk will cover how to Understand team member personality styles and their impacts according to the DiSC behavioral assessment.", 3, 1, 0, "DiSC - Understanding Yourself and Others" },
                    { 8, new DateTime(2022, 9, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), "It's easy as an engineer to get caught up in new technology trends and attempt to apply them to a new project. While this can work for smaller projects, larger clients will have many existing processes, teams, and systems that you will need to interact with that could make your shiny new technology choices less than ideal when it comes to meeting client expectations.", 3, 3, 0, "Architecting for Success" },
                    { 9, new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), "Arguably Mock Driven Development is a subset of Test Driven Development, where mock data is hosted on a proxy server to allow Engineers to easily mock API's under development. This included capturing state to vary endpoint responses to minimize backend server changes/deployments and instability.", 4, 1, 0, "Mock Driven Development for Front End Projects" }
                });

            migrationBuilder.InsertData(
                table: "TalkAuthor",
                columns: new[] { "AuthorId", "TalkId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 5 },
                    { 7, 6 },
                    { 8, 7 },
                    { 9, 8 },
                    { 10, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalkAuthor_AuthorId",
                table: "TalkAuthor",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TalkAuthor");

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "Id",
                keyValue: 9);

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
        }
    }
}
