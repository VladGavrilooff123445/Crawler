using Microsoft.EntityFrameworkCore.Migrations;

namespace Crawler.EntityFramework.Migrations
{
    public partial class newTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InSitemap",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "InWebsite",
                table: "Links");

            migrationBuilder.CreateTable(
                name: "UniqueLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InSitemap = table.Column<bool>(type: "bit", nullable: true),
                    InWebsite = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueLinks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniqueLinks");

            migrationBuilder.AddColumn<bool>(
                name: "InSitemap",
                table: "Links",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InWebsite",
                table: "Links",
                type: "bit",
                nullable: true);
        }
    }
}
