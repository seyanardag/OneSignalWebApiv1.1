using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneSignalWebApiv1.Migrations
{
    /// <inheritdoc />
    public partial class StudentPushTokenAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PushToken",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 9, 4, 10, 16, 31, 925, DateTimeKind.Local).AddTicks(3573), new TimeSpan(366919253573) });

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 9, 4, 10, 11, 31, 925, DateTimeKind.Local).AddTicks(3566), new TimeSpan(366919253569) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                columns: new[] { "CREATEDTIME", "PushToken" },
                values: new object[] { new TimeSpan(363919253480), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("954089bb-6666-44dc-928e-d4effc12169a"),
                columns: new[] { "CREATEDTIME", "PushToken" },
                values: new object[] { new TimeSpan(363919253494), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                columns: new[] { "CREATEDTIME", "PushToken" },
                values: new object[] { new TimeSpan(363919253491), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PushToken",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 9, 4, 10, 11, 22, 273, DateTimeKind.Local).AddTicks(5994), new TimeSpan(363822735995) });

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 9, 4, 10, 6, 22, 273, DateTimeKind.Local).AddTicks(5987), new TimeSpan(363822735991) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                column: "CREATEDTIME",
                value: new TimeSpan(360822735836));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("954089bb-6666-44dc-928e-d4effc12169a"),
                column: "CREATEDTIME",
                value: new TimeSpan(360822735854));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                column: "CREATEDTIME",
                value: new TimeSpan(360822735850));
        }
    }
}
