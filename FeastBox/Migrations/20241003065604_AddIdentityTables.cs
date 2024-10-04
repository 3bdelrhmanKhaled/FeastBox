using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeastBox.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 3, 9, 56, 3, 162, DateTimeKind.Local).AddTicks(9991));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 2, 22, 23, 5, 510, DateTimeKind.Local).AddTicks(4023));
        }
    }
}
