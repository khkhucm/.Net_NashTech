using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class ChangeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookRequests_ApprovalById",
                table: "BookRequests");

            migrationBuilder.UpdateData(
                table: "BookRequestDetails",
                keyColumn: "DetailId",
                keyValue: 3,
                column: "ReturnDate",
                value: new DateTime(2022, 11, 14, 0, 2, 59, 90, DateTimeKind.Local).AddTicks(3885));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestedDate",
                value: new DateTime(2022, 11, 14, 0, 2, 59, 90, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 2,
                columns: new[] { "RequestedDate", "Status" },
                values: new object[] { new DateTime(2022, 11, 14, 0, 2, 59, 90, DateTimeKind.Local).AddTicks(3866), 1 });

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 3,
                columns: new[] { "RequestedDate", "Status" },
                values: new object[] { new DateTime(2022, 11, 14, 0, 2, 59, 90, DateTimeKind.Local).AddTicks(3868), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_ApprovalById",
                table: "BookRequests",
                column: "ApprovalById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookRequests_ApprovalById",
                table: "BookRequests");

            migrationBuilder.UpdateData(
                table: "BookRequestDetails",
                keyColumn: "DetailId",
                keyValue: 3,
                column: "ReturnDate",
                value: new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestedDate",
                value: new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 2,
                columns: new[] { "RequestedDate", "Status" },
                values: new object[] { new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(836), 0 });

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 3,
                columns: new[] { "RequestedDate", "Status" },
                values: new object[] { new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(838), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_ApprovalById",
                table: "BookRequests",
                column: "ApprovalById",
                unique: true,
                filter: "[ApprovalById] IS NOT NULL");
        }
    }
}
