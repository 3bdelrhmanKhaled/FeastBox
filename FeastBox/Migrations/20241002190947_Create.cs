using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeastBox.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 2, 22, 9, 47, 154, DateTimeKind.Local).AddTicks(8329));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 2, 21, 53, 27, 31, DateTimeKind.Local).AddTicks(5402));
        }
    }
}
