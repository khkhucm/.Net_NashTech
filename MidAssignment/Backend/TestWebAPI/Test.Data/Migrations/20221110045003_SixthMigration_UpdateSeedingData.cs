using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class SixthMigration_UpdateSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalById",
                table: "BookRequests",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BookRequests",
                columns: new[] { "RequestId", "ApprovalById", "ApprovalModifiedById", "BookId", "RequestedDate", "Status", "UserId" },
                values: new object[] { 1, null, null, null, new DateTime(2022, 11, 10, 11, 50, 2, 518, DateTimeKind.Local).AddTicks(6749), 0, 1 });

            migrationBuilder.InsertData(
                table: "BookRequests",
                columns: new[] { "RequestId", "ApprovalById", "ApprovalModifiedById", "BookId", "RequestedDate", "Status", "UserId" },
                values: new object[] { 2, 3, null, null, new DateTime(2022, 11, 10, 11, 50, 2, 518, DateTimeKind.Local).AddTicks(6763), 0, 2 });

            migrationBuilder.InsertData(
                table: "BookRequests",
                columns: new[] { "RequestId", "ApprovalById", "ApprovalModifiedById", "BookId", "RequestedDate", "Status", "UserId" },
                values: new object[] { 3, 4, null, null, new DateTime(2022, 11, 10, 11, 50, 2, 518, DateTimeKind.Local).AddTicks(6764), 1, 2 });

            migrationBuilder.InsertData(
                table: "BookRequestDetails",
                columns: new[] { "DetailId", "BookId", "RequestId", "ReturnDate", "Status" },
                values: new object[] { 1, 3, 1, null, 0 });

            migrationBuilder.InsertData(
                table: "BookRequestDetails",
                columns: new[] { "DetailId", "BookId", "RequestId", "ReturnDate", "Status" },
                values: new object[] { 2, 3, 2, null, 1 });

            migrationBuilder.InsertData(
                table: "BookRequestDetails",
                columns: new[] { "DetailId", "BookId", "RequestId", "ReturnDate", "Status" },
                values: new object[] { 3, 4, 3, new DateTime(2022, 11, 10, 11, 50, 2, 518, DateTimeKind.Local).AddTicks(6780), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookRequestDetails",
                keyColumn: "DetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookRequestDetails",
                keyColumn: "DetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookRequestDetails",
                keyColumn: "DetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ApprovalById",
                table: "BookRequests");
        }
    }
}
