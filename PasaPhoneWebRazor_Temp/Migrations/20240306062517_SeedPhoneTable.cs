using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PasaPhoneWebRazor_Temp.Migrations
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
                    { 1, "Samsung", "New", new DateTime(2024, 3, 6, 14, 25, 16, 552, DateTimeKind.Local).AddTicks(5610), "Brand new phone, never used.", "None", "Quezon City, NCR", "Door Pickup", "Galaxy S20", 45000.0 },
                    { 2, "Apple", "Used - Like new", new DateTime(2024, 3, 6, 14, 25, 16, 552, DateTimeKind.Local).AddTicks(5614), "Slightly used, looks like new.", "No scratches or dents.", "Makati City, NCR", "Public Meetup", "iPhone 12 Pro", 55000.0 },
                    { 3, "OnePlus", "Used - Fair", new DateTime(2024, 3, 6, 14, 25, 16, 552, DateTimeKind.Local).AddTicks(5616), "Fairly used phone, with minor scratches.", "Small scratch on the screen.", "Cebu City, Cebu", "Door Dropoff", "8T", 28000.0 }
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
        }
    }
}
