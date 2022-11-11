using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class FifthMigration_ChangeBookRequestandBookDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequestDetails_BookRequests_BookRequestRequestId",
                table: "BookRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookRequestDetails_BookRequestRequestId",
                table: "BookRequestDetails");

            migrationBuilder.DropColumn(
                name: "BookRequestRequestId",
                table: "BookRequestDetails");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "BookRequestDetails");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "BookRequestDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "BookRequestDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookRequestDetails_RequestId",
                table: "BookRequestDetails",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequestDetails_BookRequests_RequestId",
                table: "BookRequestDetails",
                column: "RequestId",
                principalTable: "BookRequests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequestDetails_BookRequests_RequestId",
                table: "BookRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookRequestDetails_RequestId",
                table: "BookRequestDetails");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BookRequestDetails");

            migrationBuilder.AddColumn<int>(
                name: "BookRequestRequestId",
                table: "BookRequestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "BookRequestDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "BookRequestDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_BookRequestDetails_BookRequestRequestId",
                table: "BookRequestDetails",
                column: "BookRequestRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequestDetails_BookRequests_BookRequestRequestId",
                table: "BookRequestDetails",
                column: "BookRequestRequestId",
                principalTable: "BookRequests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
