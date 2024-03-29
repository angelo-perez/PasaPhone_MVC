using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasaPhone.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateModified", "ImageUrl" },
                values: new object[] { new DateTime(2024, 3, 22, 16, 45, 34, 677, DateTimeKind.Local).AddTicks(5698), null });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateModified", "ImageUrl" },
                values: new object[] { new DateTime(2024, 3, 22, 16, 45, 34, 677, DateTimeKind.Local).AddTicks(5702), null });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateModified", "ImageUrl" },
                values: new object[] { new DateTime(2024, 3, 22, 16, 45, 34, 677, DateTimeKind.Local).AddTicks(5704), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Phones");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateModified",
                value: new DateTime(2024, 3, 22, 14, 39, 9, 76, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateModified",
                value: new DateTime(2024, 3, 22, 14, 39, 9, 76, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateModified",
                value: new DateTime(2024, 3, 22, 14, 39, 9, 76, DateTimeKind.Local).AddTicks(785));
        }
    }
}
