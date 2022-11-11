using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class SeventhMigration_Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Users_ApprovalModifiedById",
                table: "BookRequests");

            migrationBuilder.RenameColumn(
                name: "ApprovalModifiedById",
                table: "BookRequests",
                newName: "ApprovalModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequests_ApprovalModifiedById",
                table: "BookRequests",
                newName: "IX_BookRequests_ApprovalModifiedByUserId");

            migrationBuilder.UpdateData(
                table: "BookRequestDetails",
                keyColumn: "DetailId",
                keyValue: 3,
                column: "ReturnDate",
                value: new DateTime(2022, 11, 11, 9, 23, 35, 618, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestedDate",
                value: new DateTime(2022, 11, 11, 9, 23, 35, 618, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 2,
                column: "RequestedDate",
                value: new DateTime(2022, 11, 11, 9, 23, 35, 618, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestedDate",
                value: new DateTime(2022, 11, 11, 9, 23, 35, 618, DateTimeKind.Local).AddTicks(7575));

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Users_ApprovalModifiedByUserId",
                table: "BookRequests",
                column: "ApprovalModifiedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Users_ApprovalModifiedByUserId",
                table: "BookRequests");

            migrationBuilder.RenameColumn(
                name: "ApprovalModifiedByUserId",
                table: "BookRequests",
                newName: "ApprovalModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequests_ApprovalModifiedByUserId",
                table: "BookRequests",
                newName: "IX_BookRequests_ApprovalModifiedById");

            migrationBuilder.UpdateData(
                table: "BookRequestDetails",
                keyColumn: "DetailId",
                keyValue: 3,
                column: "ReturnDate",
                value: new DateTime(2022, 11, 10, 11, 50, 2, 518, DateTimeKind.Local).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestedDate",
                value: new DateTime(2022, 11, 10, 11, 50, 2, 518, DateTimeKind.Local).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 2,
                column: "RequestedDate",
                value: new DateTime(2022, 11, 10, 11, 50, 2, 518, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestedDate",
                value: new DateTime(2022, 11, 10, 11, 50, 2, 518, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Users_ApprovalModifiedById",
                table: "BookRequests",
                column: "ApprovalModifiedById",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
