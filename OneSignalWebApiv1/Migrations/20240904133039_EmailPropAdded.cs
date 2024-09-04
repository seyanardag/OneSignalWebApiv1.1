using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneSignalWebApiv1.Migrations
{
    /// <inheritdoc />
    public partial class EmailPropAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 9, 4, 16, 40, 39, 104, DateTimeKind.Local).AddTicks(9114), new TimeSpan(597391049115) });

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 9, 4, 16, 35, 39, 104, DateTimeKind.Local).AddTicks(9106), new TimeSpan(597391049109) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                columns: new[] { "CREATEDTIME", "Email" },
                values: new object[] { new TimeSpan(594391049005), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("954089bb-6666-44dc-928e-d4effc12169a"),
                columns: new[] { "CREATEDTIME", "Email" },
                values: new object[] { new TimeSpan(594391049020), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                columns: new[] { "CREATEDTIME", "Email" },
                values: new object[] { new TimeSpan(594391049015), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 9, 4, 15, 54, 41, 569, DateTimeKind.Local).AddTicks(2244), new TimeSpan(569815692245) });

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 9, 4, 15, 49, 41, 569, DateTimeKind.Local).AddTicks(2237), new TimeSpan(569815692241) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                column: "CREATEDTIME",
                value: new TimeSpan(566815692121));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("954089bb-6666-44dc-928e-d4effc12169a"),
                column: "CREATEDTIME",
                value: new TimeSpan(566815692136));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                column: "CREATEDTIME",
                value: new TimeSpan(566815692133));
        }
    }
}
