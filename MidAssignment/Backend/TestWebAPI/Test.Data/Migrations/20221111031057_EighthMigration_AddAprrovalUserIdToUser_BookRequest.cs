using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class EighthMigration_AddAprrovalUserIdToUser_BookRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Users_ApprovalModifiedByUserId",
                table: "BookRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_ApprovalModifiedByUserId",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "ApprovalModifiedByUserId",
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
                column: "RequestedDate",
                value: new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(836));

            migrationBuilder.UpdateData(
                table: "BookRequests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestedDate",
                value: new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(838));

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_ApprovalById",
                table: "BookRequests",
                column: "ApprovalById",
                unique: true,
                filter: "[ApprovalById] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Users_ApprovalById",
                table: "BookRequests",
                column: "ApprovalById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Users_ApprovalById",
                table: "BookRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_ApprovalById",
                table: "BookRequests");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalModifiedByUserId",
                table: "BookRequests",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_ApprovalModifiedByUserId",
                table: "BookRequests",
                column: "ApprovalModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Users_ApprovalModifiedByUserId",
                table: "BookRequests",
                column: "ApprovalModifiedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
