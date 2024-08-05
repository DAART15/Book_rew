using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_rew.Migrations
{
    /// <inheritdoc />
    public partial class addedBookInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "PublishedTime", "Title" },
                values: new object[] { 1, "Dan Brown", "1234567890123", new DateTime(2024, 8, 2, 17, 12, 24, 404, DateTimeKind.Local).AddTicks(9797), "Digital Fortress" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
