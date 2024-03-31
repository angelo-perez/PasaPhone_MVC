using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasaPhone.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ConvertMemoryAndStorageToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Storage",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Memory",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateModified",
                value: new DateTime(2024, 3, 31, 10, 55, 43, 373, DateTimeKind.Local).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateModified",
                value: new DateTime(2024, 3, 31, 10, 55, 43, 373, DateTimeKind.Local).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateModified",
                value: new DateTime(2024, 3, 31, 10, 55, 43, 373, DateTimeKind.Local).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: 1,
                columns: new[] { "Memory", "Storage" },
                values: new object[] { "12GB", "128GB" });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: 2,
                columns: new[] { "Memory", "Storage" },
                values: new object[] { "6GB", "128GB" });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: 3,
                columns: new[] { "Memory", "Storage" },
                values: new object[] { "8GB", "128GB" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Storage",
                table: "Specifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Memory",
                table: "Specifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateModified",
                value: new DateTime(2024, 3, 27, 14, 36, 3, 837, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateModified",
                value: new DateTime(2024, 3, 27, 14, 36, 3, 837, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateModified",
                value: new DateTime(2024, 3, 27, 14, 36, 3, 837, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: 1,
                columns: new[] { "Memory", "Storage" },
                values: new object[] { 12, 128 });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: 2,
                columns: new[] { "Memory", "Storage" },
                values: new object[] { 6, 128 });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: 3,
                columns: new[] { "Memory", "Storage" },
                values: new object[] { 8, 128 });
        }
    }
}
