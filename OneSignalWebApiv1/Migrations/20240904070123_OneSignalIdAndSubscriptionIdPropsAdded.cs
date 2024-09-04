using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneSignalWebApiv1.Migrations
{
    /// <inheritdoc />
    public partial class OneSignalIdAndSubscriptionIdPropsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OneSignalId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "CREATEDDATE", "CREATEDTIME", "OneSignalId", "SubscriptionId" },
                values: new object[] { new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(360822735836), null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("954089bb-6666-44dc-928e-d4effc12169a"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME", "OneSignalId", "SubscriptionId" },
                values: new object[] { new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(360822735854), null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME", "OneSignalId", "SubscriptionId" },
                values: new object[] { new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(360822735850), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OneSignalId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 14, 42, 56, 783, DateTimeKind.Local).AddTicks(717), new TimeSpan(526767830717) });

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 14, 37, 56, 783, DateTimeKind.Local).AddTicks(709), new TimeSpan(526767830713) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(523767830609) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("954089bb-6666-44dc-928e-d4effc12169a"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(523767830631) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(523767830620) });
        }
    }
}
