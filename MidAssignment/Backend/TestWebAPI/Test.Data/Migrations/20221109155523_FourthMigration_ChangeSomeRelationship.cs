using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class FourthMigration_ChangeSomeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Users_ApprovedById",
                table: "BookRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Users_RejectedById",
                table: "BookRequests");

            migrationBuilder.DropTable(
                name: "BookBookRequest");

            migrationBuilder.RenameColumn(
                name: "RejectedById",
                table: "BookRequests",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "ApprovedById",
                table: "BookRequests",
                newName: "ApprovalModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequests_RejectedById",
                table: "BookRequests",
                newName: "IX_BookRequests_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequests_ApprovedById",
                table: "BookRequests",
                newName: "IX_BookRequests_ApprovalModifiedById");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookRequestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BookRequestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookRequestDetails_BookId",
                table: "BookRequestDetails",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequestDetails_Books_BookId",
                table: "BookRequestDetails",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Books_BookId",
                table: "BookRequests",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Users_ApprovalModifiedById",
                table: "BookRequests",
                column: "ApprovalModifiedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequestDetails_Books_BookId",
                table: "BookRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Books_BookId",
                table: "BookRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Users_ApprovalModifiedById",
                table: "BookRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookRequestDetails_BookId",
                table: "BookRequestDetails");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookRequestDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BookRequestDetails");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookRequests",
                newName: "RejectedById");

            migrationBuilder.RenameColumn(
                name: "ApprovalModifiedById",
                table: "BookRequests",
                newName: "ApprovedById");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequests_BookId",
                table: "BookRequests",
                newName: "IX_BookRequests_RejectedById");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequests_ApprovalModifiedById",
                table: "BookRequests",
                newName: "IX_BookRequests_ApprovedById");

            migrationBuilder.CreateTable(
                name: "BookBookRequest",
                columns: table => new
                {
                    BookRequestsRequestId = table.Column<int>(type: "int", nullable: false),
                    BooksBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookRequest", x => new { x.BookRequestsRequestId, x.BooksBookId });
                    table.ForeignKey(
                        name: "FK_BookBookRequest_BookRequests_BookRequestsRequestId",
                        column: x => x.BookRequestsRequestId,
                        principalTable: "BookRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookRequest_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookRequest_BooksBookId",
                table: "BookBookRequest",
                column: "BooksBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Users_ApprovedById",
                table: "BookRequests",
                column: "ApprovedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Users_RejectedById",
                table: "BookRequests",
                column: "RejectedById",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
