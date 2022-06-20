using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class PlanoAlimentarAtualizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefeicaoEntity_Pacientes_PacienteEntityId",
                table: "RefeicaoEntity");

            migrationBuilder.RenameColumn(
                name: "PacienteEntityId",
                table: "RefeicaoEntity",
                newName: "PlanoAlimentarEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_RefeicaoEntity_PacienteEntityId",
                table: "RefeicaoEntity",
                newName: "IX_RefeicaoEntity_PlanoAlimentarEntityId");

            migrationBuilder.RenameColumn(
                name: "Alimento",
                table: "AlimentoEntity",
                newName: "Nome");

            migrationBuilder.CreateTable(
                name: "PlanoAlimentarEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacienteEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoAlimentarEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoAlimentarEntity_Pacientes_PacienteEntityId",
                        column: x => x.PacienteEntityId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAlimentarEntity_PacienteEntityId",
                table: "PlanoAlimentarEntity",
                column: "PacienteEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefeicaoEntity_PlanoAlimentarEntity_PlanoAlimentarEntityId",
                table: "RefeicaoEntity",
                column: "PlanoAlimentarEntityId",
                principalTable: "PlanoAlimentarEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefeicaoEntity_PlanoAlimentarEntity_PlanoAlimentarEntityId",
                table: "RefeicaoEntity");

            migrationBuilder.DropTable(
                name: "PlanoAlimentarEntity");

            migrationBuilder.RenameColumn(
                name: "PlanoAlimentarEntityId",
                table: "RefeicaoEntity",
                newName: "PacienteEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_RefeicaoEntity_PlanoAlimentarEntityId",
                table: "RefeicaoEntity",
                newName: "IX_RefeicaoEntity_PacienteEntityId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "AlimentoEntity",
                newName: "Alimento");

            migrationBuilder.AddForeignKey(
                name: "FK_RefeicaoEntity_Pacientes_PacienteEntityId",
                table: "RefeicaoEntity",
                column: "PacienteEntityId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
