using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasaPhone.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameForeignKeyToSpecificationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specifications_Phones_PhoneId",
                table: "Specifications");

            migrationBuilder.RenameColumn(
                name: "PhoneId",
                table: "Specifications",
                newName: "SpecificationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Specifications_Phones_SpecificationId",
                table: "Specifications",
                column: "SpecificationId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specifications_Phones_SpecificationId",
                table: "Specifications");

            migrationBuilder.RenameColumn(
                name: "SpecificationId",
                table: "Specifications",
                newName: "PhoneId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Specifications_Phones_PhoneId",
                table: "Specifications",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
