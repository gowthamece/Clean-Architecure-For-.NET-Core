using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelBooking.Persistance.Migrations
{
    public partial class InitalCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("1980c204-e67f-4bd9-ab0d-de94217527b3"), "Shaaniya" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
