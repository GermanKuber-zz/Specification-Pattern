using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Events.Data.Migrations
{
    public partial class First_Migration : Migration
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
                    Premium = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventDate", "Guests", "Premium", "Title", "Validated" },
                values: new object[] { 1, new DateTime(2018, 8, 29, 15, 2, 25, 669, DateTimeKind.Local), 6, false, "Meetup.Js Event", false });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventDate", "Guests", "Premium", "Title", "Validated" },
                values: new object[] { 2, new DateTime(2018, 8, 23, 15, 2, 25, 673, DateTimeKind.Local), 30, false, "Specification Pattern en C#", false });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventDate", "Guests", "Premium", "Title", "Validated" },
                values: new object[] { 3, new DateTime(2018, 8, 23, 15, 2, 25, 673, DateTimeKind.Local), 25, true, "Azure and Docker", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
