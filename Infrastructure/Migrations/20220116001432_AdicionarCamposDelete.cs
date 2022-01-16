using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AdicionarCamposDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Nutricionistas");

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

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Nutricionistas");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Nutricionistas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
