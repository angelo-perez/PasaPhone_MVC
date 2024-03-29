using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasaPhone.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForPhoneSpecificationRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_PhoneId",
                table: "Specifications",
                column: "PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specifications_Phones_PhoneId",
                table: "Specifications",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specifications_Phones_PhoneId",
                table: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_Specifications_PhoneId",
                table: "Specifications");

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
        }
    }
}
