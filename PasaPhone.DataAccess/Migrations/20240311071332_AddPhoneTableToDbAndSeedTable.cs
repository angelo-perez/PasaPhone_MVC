using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PasaPhone.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneTableToDbAndSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetupPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "Condition", "DateModified", "Description", "Issues", "Location", "MeetupPreference", "Model", "Price" },
                values: new object[,]
                {
                    { 1, "Samsung", "New", new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4547), "Brand new phone, never used.", "None", "Quezon City, NCR", "Door Pickup", "Galaxy S20", 45000.0 },
                    { 2, "Apple", "Used - Like new", new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4550), "Slightly used, looks like new.", "No scratches or dents.", "Makati City, NCR", "Public Meetup", "iPhone 12 Pro", 55000.0 },
                    { 3, "OnePlus", "Used - Fair", new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4553), "Fairly used phone, with minor scratches.", "Small scratch on the screen.", "Cebu City, Cebu", "Door Dropoff", "8T", 28000.0 },
                    { 4, "Xiaomi", "New", new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4555), "Fresh out of the box, never been used.", "None", "Davao City, Davao", "Public Meetup", "Redmi Note 10", 12000.0 },
                    { 5, "Realme", "Used - Good", new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4557), "Good condition, used for a few months.", "Minor wear and tear on the back.", "Manila City, NCR", "Door Pickup", "X7 Max", 20000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
