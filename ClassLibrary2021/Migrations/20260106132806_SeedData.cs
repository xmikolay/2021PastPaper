using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClassLibrary2021.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarID", "Class", "CostPerDay", "Make", "Model" },
                values: new object[,]
                {
                    { 1, "Economy", 51.83m, "VW", "Polo" },
                    { 2, "Compact", 59.93m, "Ford", "Focus" },
                    { 3, "Compact", 56.87m, "Ford", "Puma" },
                    { 4, "Mini", 50.92m, "VW", "UP" },
                    { 5, "Standard", 66.22m, "Ford", "Kuga" }
                });

            migrationBuilder.InsertData(
                table: "Hires",
                columns: new[] { "HireID", "CarID", "DropOffLocation", "ExtraCharge", "HireEndDate", "HireStartDate", "PickUpLocation" },
                values: new object[,]
                {
                    { 1, 1, "Sligo", 30m, new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sligo" },
                    { 2, 1, "Dublin Airport", 127.56m, new DateTime(2021, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sligo" },
                    { 3, 5, "Sligo", 30m, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sligo" },
                    { 4, 5, "Sligo", 30m, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sligo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hires",
                keyColumn: "HireID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hires",
                keyColumn: "HireID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hires",
                keyColumn: "HireID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hires",
                keyColumn: "HireID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 5);
        }
    }
}
