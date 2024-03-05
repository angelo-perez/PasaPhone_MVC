using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasaPhoneWeb.Migrations
{
    /// <inheritdoc />
    public partial class MakePriceAndDescriptionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Issues",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateModified",
                value: new DateTime(2024, 2, 28, 11, 55, 57, 741, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateModified",
                value: new DateTime(2024, 2, 28, 11, 55, 57, 741, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateModified",
                value: new DateTime(2024, 2, 28, 11, 55, 57, 741, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateModified",
                value: new DateTime(2024, 2, 28, 11, 55, 57, 741, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateModified",
                value: new DateTime(2024, 2, 28, 11, 55, 57, 741, DateTimeKind.Local).AddTicks(791));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Issues",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateModified",
                value: new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateModified",
                value: new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6383));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateModified",
                value: new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateModified",
                value: new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateModified",
                value: new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6389));
        }
    }
}
