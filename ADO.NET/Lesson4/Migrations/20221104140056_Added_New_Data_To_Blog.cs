using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_core.Migrations
{
    public partial class Added_New_Data_To_Blog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorName", "Content", "LikeCount", "Url" },
                values: new object[] { 1, "Nurik", "i'm Mickelangelo.", 10000000, "cartoonnetwork.com" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorName", "Content", "LikeCount", "Url" },
                values: new object[] { 2, "Katya", "i'm Batman", 250000, "tiktok.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
