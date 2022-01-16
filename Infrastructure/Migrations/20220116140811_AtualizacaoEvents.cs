using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AtualizacaoEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Nutricionistas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Pacientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Nutricionistas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
