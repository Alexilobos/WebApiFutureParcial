using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiFuture.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Future",
                columns: table => new
                {
                    FuturoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    vision = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Enlace = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Future", x => x.FuturoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Future");
        }
    }
}
