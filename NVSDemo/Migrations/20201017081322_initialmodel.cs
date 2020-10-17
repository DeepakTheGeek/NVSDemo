using Microsoft.EntityFrameworkCore.Migrations;

namespace NVSDemo.Migrations
{
    public partial class initialmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landmarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandmarkName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Latitude = table.Column<decimal>(type: "Decimal(8,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "Decimal(9,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landmarks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Landmarks");
        }
    }
}
