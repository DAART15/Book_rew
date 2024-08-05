using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_rew.Migrations
{
    /// <inheritdoc />
    public partial class AddedReviewIitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedTime",
                value: new DateTime(2024, 8, 2, 17, 57, 18, 420, DateTimeKind.Local).AddTicks(2896));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "Rating", "ReviewerName" },
                values: new object[] { 1, 1, "One of the best", 5, "Ramas" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedTime",
                value: new DateTime(2024, 8, 2, 17, 12, 24, 404, DateTimeKind.Local).AddTicks(9797));
        }
    }
}
