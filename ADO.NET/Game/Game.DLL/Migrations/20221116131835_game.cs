using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DLL.Migrations
{
    /// <inheritdoc />
    public partial class game : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDeveloper = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sells = table.Column<int>(type: "int", nullable: false),
                    PublishYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GameDeveloper", "GameMode", "GameName", "GameStyle", "PublishYear", "Sells" },
                values: new object[] { 1, "Santa Monica Studio", "God killer", "God of war", "Action", 2018, 10000000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
