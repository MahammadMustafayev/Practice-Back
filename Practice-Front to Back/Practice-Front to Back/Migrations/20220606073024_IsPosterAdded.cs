using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice_Front_to_Back.Migrations
{
    public partial class IsPosterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPoster",
                table: "ProductImages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPoster",
                table: "ProductImages");
        }
    }
}
