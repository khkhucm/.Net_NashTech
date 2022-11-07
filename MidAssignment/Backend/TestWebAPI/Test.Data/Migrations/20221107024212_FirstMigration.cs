﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectedById = table.Column<int>(type: "int", nullable: true),
                    ApprovedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequests_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequests_Users_RejectedById",
                        column: x => x.RejectedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBookBorrowingRequest",
                columns: table => new
                {
                    BookBorrowingRequestsRequestId = table.Column<int>(type: "int", nullable: false),
                    BooksBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookBorrowingRequest", x => new { x.BookBorrowingRequestsRequestId, x.BooksBookId });
                    table.ForeignKey(
                        name: "FK_BookBookBorrowingRequest_BookBorrowingRequests_BookBorrowingRequestsRequestId",
                        column: x => x.BookBorrowingRequestsRequestId,
                        principalTable: "BookBorrowingRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookBorrowingRequest_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequestDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    BookBorrowingRequestRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequestDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetails_BookBorrowingRequests_BookBorrowingRequestRequestId",
                        column: x => x.BookBorrowingRequestRequestId,
                        principalTable: "BookBorrowingRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Culture" },
                    { 2, "Science" },
                    { 3, "Travel" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Gender", "Name", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, null, null, "Normal 1", "123456", 1, "user1" },
                    { 2, null, null, "Normal 2", "123456", 1, "user2" },
                    { 3, null, null, "Super 1", "123456", 0, "sa1" },
                    { 4, null, null, "Super 2", "123456", 0, "sa2" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookName", "CategoryId" },
                values: new object[,]
                {
                    { 1, "Book 1", 1 },
                    { 2, "Book 2", 2 },
                    { 3, "Book 3", 1 },
                    { 4, "Book 4", 3 },
                    { 5, "Book 5", 1 },
                    { 6, "Book 6", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookBorrowingRequest_BooksBookId",
                table: "BookBookBorrowingRequest",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequestDetails_BookBorrowingRequestRequestId",
                table: "BookBorrowingRequestDetails",
                column: "BookBorrowingRequestRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequests_ApprovedById",
                table: "BookBorrowingRequests",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequests_RejectedById",
                table: "BookBorrowingRequests",
                column: "RejectedById");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequests_UserId",
                table: "BookBorrowingRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookBorrowingRequest");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequestDetails");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequests");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
