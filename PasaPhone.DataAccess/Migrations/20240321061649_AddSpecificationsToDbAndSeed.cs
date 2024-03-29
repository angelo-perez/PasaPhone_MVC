using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PasaPhone.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecificationsToDbAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneId = table.Column<int>(type: "int", nullable: false),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Camera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Os = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Memory = table.Column<int>(type: "int", nullable: false),
                    Storage = table.Column<int>(type: "int", nullable: false),
                    BatteryCapacity = table.Column<int>(type: "int", nullable: false),
                    ChargingSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherSpecs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateModified",
                value: new DateTime(2024, 3, 21, 14, 16, 48, 472, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateModified",
                value: new DateTime(2024, 3, 21, 14, 16, 48, 472, DateTimeKind.Local).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateModified",
                value: new DateTime(2024, 3, 21, 14, 16, 48, 472, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "BatteryCapacity", "Camera", "ChargingSpeed", "Chipset", "DisplayResolution", "DisplayType", "Memory", "Os", "OtherSpecs", "PhoneId", "Storage" },
                values: new object[,]
                {
                    { 1, 4000, "Triple - 12 MP wide, 64 MP telephoto, 12 MP ultrawide", "Fast charging 25W, USB Power Delivery 3.0, Fast Qi/PMA wireless charging 15W, Reverse wireless charging 4.5W", "Exynos 990 (Global) / Qualcomm Snapdragon 865 (USA)", "Quad HD+", "Dynamic AMOLED 2X", 12, "Android", "IP68 dust/water resistant (up to 1.5m for 30 mins), HDR10+, 120Hz refresh rate", 1, 128 },
                    { 2, 2815, "Triple - 12 MP wide, 12 MP telephoto, 12 MP ultrawide", "Fast charging 20W, 50% in 30 min (advertised), USB Power Delivery 2.0, MagSafe wireless charging 15W", "Apple A14 Bionic", "Full HD+", "Super Retina XDR OLED", 6, "iOS", "IP68 dust/water resistant (up to 6m for 30 mins), Ceramic Shield front, HDR10, Dolby Vision", 2, 128 },
                    { 3, 4500, "Quad - 48 MP wide, 16 MP ultrawide, 5 MP macro, 2 MP depth", "Fast charging 65W, 100% in 39 min (advertised), Reverse charging 3W", "Qualcomm Snapdragon 865", "Full HD+", "Fluid AMOLED", 8, "Android", "HDR10+, 120Hz refresh rate, Corning Gorilla Glass 5", 3, 128 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateModified",
                value: new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateModified",
                value: new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4550));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateModified",
                value: new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4553));

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "Condition", "DateModified", "Description", "Issues", "Location", "MeetupPreference", "Model", "Price" },
                values: new object[,]
                {
                    { 4, "Xiaomi", "New", new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4555), "Fresh out of the box, never been used.", "None", "Davao City, Davao", "Public Meetup", "Redmi Note 10", 12000.0 },
                    { 5, "Realme", "Used - Good", new DateTime(2024, 3, 11, 15, 13, 31, 747, DateTimeKind.Local).AddTicks(4557), "Good condition, used for a few months.", "Minor wear and tear on the back.", "Manila City, NCR", "Door Pickup", "X7 Max", 20000.0 }
                });
        }
    }
}
