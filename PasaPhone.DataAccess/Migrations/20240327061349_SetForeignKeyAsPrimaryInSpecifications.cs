using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PasaPhone.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SetForeignKeyAsPrimaryInSpecifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Specifications",
                table: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_Specifications_PhoneId",
                table: "Specifications");

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Specifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specifications",
                table: "Specifications",
                column: "PhoneId");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateModified",
                value: new DateTime(2024, 3, 27, 14, 13, 48, 349, DateTimeKind.Local).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateModified",
                value: new DateTime(2024, 3, 27, 14, 13, 48, 349, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateModified",
                value: new DateTime(2024, 3, 27, 14, 13, 48, 349, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "PhoneId", "BatteryCapacity", "Camera", "ChargingSpeed", "Chipset", "DisplayResolution", "DisplayType", "Memory", "Os", "OtherSpecs", "Storage" },
                values: new object[,]
                {
                    { 1, 4000, "Triple - 12 MP wide, 64 MP telephoto, 12 MP ultrawide", "Fast charging 25W, USB Power Delivery 3.0, Fast Qi/PMA wireless charging 15W, Reverse wireless charging 4.5W", "Exynos 990 (Global) / Qualcomm Snapdragon 865 (USA)", "Quad HD+", "Dynamic AMOLED 2X", 12, "Android", "IP68 dust/water resistant (up to 1.5m for 30 mins), HDR10+, 120Hz refresh rate", 128 },
                    { 2, 2815, "Triple - 12 MP wide, 12 MP telephoto, 12 MP ultrawide", "Fast charging 20W, 50% in 30 min (advertised), USB Power Delivery 2.0, MagSafe wireless charging 15W", "Apple A14 Bionic", "Full HD+", "Super Retina XDR OLED", 6, "iOS", "IP68 dust/water resistant (up to 6m for 30 mins), Ceramic Shield front, HDR10, Dolby Vision", 128 },
                    { 3, 4500, "Quad - 48 MP wide, 16 MP ultrawide, 5 MP macro, 2 MP depth", "Fast charging 65W, 100% in 39 min (advertised), Reverse charging 3W", "Qualcomm Snapdragon 865", "Full HD+", "Fluid AMOLED", 8, "Android", "HDR10+, 120Hz refresh rate, Corning Gorilla Glass 5", 128 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Specifications",
                table: "Specifications");

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "PhoneId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "PhoneId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "PhoneId",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specifications",
                table: "Specifications",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateModified",
                value: new DateTime(2024, 3, 26, 14, 44, 46, 57, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateModified",
                value: new DateTime(2024, 3, 26, 14, 44, 46, 57, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateModified",
                value: new DateTime(2024, 3, 26, 14, 44, 46, 57, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "BatteryCapacity", "Camera", "ChargingSpeed", "Chipset", "DisplayResolution", "DisplayType", "Memory", "Os", "OtherSpecs", "PhoneId", "Storage" },
                values: new object[,]
                {
                    { 1, 4000, "Triple - 12 MP wide, 64 MP telephoto, 12 MP ultrawide", "Fast charging 25W, USB Power Delivery 3.0, Fast Qi/PMA wireless charging 15W, Reverse wireless charging 4.5W", "Exynos 990 (Global) / Qualcomm Snapdragon 865 (USA)", "Quad HD+", "Dynamic AMOLED 2X", 12, "Android", "IP68 dust/water resistant (up to 1.5m for 30 mins), HDR10+, 120Hz refresh rate", 1, 128 },
                    { 2, 2815, "Triple - 12 MP wide, 12 MP telephoto, 12 MP ultrawide", "Fast charging 20W, 50% in 30 min (advertised), USB Power Delivery 2.0, MagSafe wireless charging 15W", "Apple A14 Bionic", "Full HD+", "Super Retina XDR OLED", 6, "iOS", "IP68 dust/water resistant (up to 6m for 30 mins), Ceramic Shield front, HDR10, Dolby Vision", 2, 128 },
                    { 3, 4500, "Quad - 48 MP wide, 16 MP ultrawide, 5 MP macro, 2 MP depth", "Fast charging 65W, 100% in 39 min (advertised), Reverse charging 3W", "Qualcomm Snapdragon 865", "Full HD+", "Fluid AMOLED", 8, "Android", "HDR10+, 120Hz refresh rate, Corning Gorilla Glass 5", 3, 128 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_PhoneId",
                table: "Specifications",
                column: "PhoneId");
        }
    }
}
