using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PasaPhoneWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedPhoneTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "Condition", "DateModified", "Description", "Issues", "Location", "MeetupPreference", "Model", "Price" },
                values: new object[,]
                {
                    { 1, "Samsung", "New", new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6381), "Brand new phone, never used.", "None", "Quezon City, NCR", "Door Pickup", "Galaxy S20", 45000.0 },
                    { 2, "Apple", "Used - Like new", new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6383), "Slightly used, looks like new.", "No scratches or dents.", "Makati City, NCR", "Public Meetup", "iPhone 12 Pro", 55000.0 },
                    { 3, "OnePlus", "Used - Fair", new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6385), "Fairly used phone, with minor scratches.", "Small scratch on the screen.", "Cebu City, Cebu", "Door Dropoff", "8T", 28000.0 },
                    { 4, "Xiaomi", "New", new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6387), "Fresh out of the box, never been used.", "None", "Davao City, Davao", "Public Meetup", "Redmi Note 10", 12000.0 },
                    { 5, "Realme", "Used - Good", new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6389), "Good condition, used for a few months.", "Minor wear and tear on the back.", "Manila City, NCR", "Door Pickup", "X7 Max", 20000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
