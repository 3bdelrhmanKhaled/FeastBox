using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeastBox.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 3, 10, 28, 15, 482, DateTimeKind.Local).AddTicks(1264));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 3, 10, 11, 53, 778, DateTimeKind.Local).AddTicks(9729));
        }
    }
}
