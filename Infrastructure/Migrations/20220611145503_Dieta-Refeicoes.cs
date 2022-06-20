using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class DietaRefeicoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefeicaoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefeicaoEntity_Pacientes_PacienteEntityId",
                        column: x => x.PacienteEntityId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlimentoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medida = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    RefeicaoEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlimentoEntity_RefeicaoEntity_RefeicaoEntityId",
                        column: x => x.RefeicaoEntityId,
                        principalTable: "RefeicaoEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentoEntity_RefeicaoEntityId",
                table: "AlimentoEntity",
                column: "RefeicaoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RefeicaoEntity_PacienteEntityId",
                table: "RefeicaoEntity",
                column: "PacienteEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentoEntity");

            migrationBuilder.DropTable(
                name: "RefeicaoEntity");
        }
    }
}
