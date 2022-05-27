using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice_Front_to_Back.Migrations
{
    public partial class RedirectUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RedirectUrl",
                table: "Sliders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RedirectUrlText",
                table: "Sliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedirectUrl",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "RedirectUrlText",
                table: "Sliders");
        }
    }
}
