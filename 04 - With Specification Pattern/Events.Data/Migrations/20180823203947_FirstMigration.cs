using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Events.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Guests = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    Validated = table.Column<bool>(nullable: false),
                    Premium = table.Column<bool>(nullable: false),
                    Closed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Closed", "EventDate", "Guests", "Premium", "Title", "Validated" },
                values: new object[] { 1, false, new DateTime(2018, 8, 30, 17, 39, 45, 732, DateTimeKind.Local), 6, false, "Meetup.Js Event", false });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Closed", "EventDate", "Guests", "Premium", "Title", "Validated" },
                values: new object[] { 2, false, new DateTime(2018, 8, 24, 17, 39, 45, 737, DateTimeKind.Local), 30, false, "Specification Pattern en C#", false });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Closed", "EventDate", "Guests", "Premium", "Title", "Validated" },
                values: new object[] { 3, false, new DateTime(2018, 8, 24, 17, 39, 45, 737, DateTimeKind.Local), 25, true, "Azure and Docker", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
