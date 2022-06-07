using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Title = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Title = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumTitle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Images_Albums_AlbumTitle",
                        column: x => x.AlbumTitle,
                        principalTable: "Albums",
                        principalColumn: "Title");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_AlbumTitle",
                table: "Images",
                column: "AlbumTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
