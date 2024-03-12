using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestDesign.Data.Migrations
{
    public partial class updateproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");
        }
    }
}
