using Microsoft.EntityFrameworkCore.Migrations;

namespace MLCandidate.Data.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CommentStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Pending" });

            migrationBuilder.InsertData(
                table: "CommentStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Under Review" });

            migrationBuilder.InsertData(
                table: "CommentStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "Posted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommentStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CommentStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CommentStatuses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
