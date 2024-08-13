using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_rew.Migrations
{
    /// <inheritdoc />
    public partial class addedOneToManyBookReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedTime",
                value: new DateTime(2024, 8, 13, 18, 43, 6, 553, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedTime",
                value: new DateTime(2024, 8, 2, 17, 57, 18, 420, DateTimeKind.Local).AddTicks(2896));
        }
    }
}
