using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Medidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Pacientes");

            migrationBuilder.AddColumn<Guid>(
                name: "MedidasId",
                table: "Pacientes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedidaEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesoAtual = table.Column<float>(type: "real", nullable: false),
                    PesoIdeal = table.Column<float>(type: "real", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedidaEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CircunferenciasEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BracoRelaxadoDireito = table.Column<float>(type: "real", nullable: false),
                    BracoRelaxadoEsquerdo = table.Column<float>(type: "real", nullable: false),
                    BracoContraidoDireito = table.Column<float>(type: "real", nullable: false),
                    BracoContraidoEsquerdo = table.Column<float>(type: "real", nullable: false),
                    AntebracoDireito = table.Column<float>(type: "real", nullable: false),
                    AntebracoEsquerdo = table.Column<float>(type: "real", nullable: false),
                    PunhoDireito = table.Column<float>(type: "real", nullable: false),
                    PunhoEsquerdo = table.Column<float>(type: "real", nullable: false),
                    Pescoso = table.Column<float>(type: "real", nullable: false),
                    Ombro = table.Column<float>(type: "real", nullable: false),
                    Peitoral = table.Column<float>(type: "real", nullable: false),
                    Cintura = table.Column<float>(type: "real", nullable: false),
                    Abdomen = table.Column<float>(type: "real", nullable: false),
                    Quadril = table.Column<float>(type: "real", nullable: false),
                    PanturrilhaDireita = table.Column<float>(type: "real", nullable: false),
                    PanturrilhaEsquerda = table.Column<float>(type: "real", nullable: false),
                    CoxaDireita = table.Column<float>(type: "real", nullable: false),
                    CoxaEsquerda = table.Column<float>(type: "real", nullable: false),
                    CoxaProximalDireita = table.Column<float>(type: "real", nullable: false),
                    CoxaProximalEsquerda = table.Column<float>(type: "real", nullable: false),
                    MedidaEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircunferenciasEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircunferenciasEntity_MedidaEntity_MedidaEntityId",
                        column: x => x.MedidaEntityId,
                        principalTable: "MedidaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_MedidasId",
                table: "Pacientes",
                column: "MedidasId");

            migrationBuilder.CreateIndex(
                name: "IX_CircunferenciasEntity_MedidaEntityId",
                table: "CircunferenciasEntity",
                column: "MedidaEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_MedidaEntity_MedidasId",
                table: "Pacientes",
                column: "MedidasId",
                principalTable: "MedidaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_MedidaEntity_MedidasId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "CircunferenciasEntity");

            migrationBuilder.DropTable(
                name: "MedidaEntity");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_MedidasId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "MedidasId",
                table: "Pacientes");

            migrationBuilder.AddColumn<float>(
                name: "Altura",
                table: "Pacientes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Peso",
                table: "Pacientes",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
