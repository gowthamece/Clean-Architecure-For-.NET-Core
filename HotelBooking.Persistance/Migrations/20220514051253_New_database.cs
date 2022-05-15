using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelBooking.Persistance.Migrations
{
    public partial class New_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("1980c204-e67f-4bd9-ab0d-de94217527b3"));

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("4bc8a1db-a381-416b-9984-539c2db742a4"), "Shaaniya" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("4bc8a1db-a381-416b-9984-539c2db742a4"));

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("1980c204-e67f-4bd9-ab0d-de94217527b3"), "Shaaniya" });
        }
    }
}
