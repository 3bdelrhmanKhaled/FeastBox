using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeastBox.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerIdToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // إضافة عمود CustomerId إلى جدول Orders
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            // هنا يمكنك إضافة الكود لتحديث البيانات الحالية إذا لزم الأمر
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 3, 10, 34, 22, 238, DateTimeKind.Local).AddTicks(1618));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // إزالة عمود CustomerId في حالة التراجع عن الترحيل
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 3, 10, 28, 15, 482, DateTimeKind.Local).AddTicks(1264));
        }
    }
}
