using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVCLesson1.NewAdmin.Migrations
{
    /// <inheritdoc />
    public partial class AddMainPicturePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainPicturePath",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPicturePath",
                table: "Rooms");
        }
    }
}
