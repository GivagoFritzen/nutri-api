using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Nutricionistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionistas", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<bool>(type: "bit", nullable: false),
                    MedidasId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_MedidaEntity_MedidasId",
                        column: x => x.MedidasId,
                        principalTable: "MedidaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CircunferenciasEntity_MedidaEntityId",
                table: "CircunferenciasEntity",
                column: "MedidaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_MedidasId",
                table: "Pacientes",
                column: "MedidasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CircunferenciasEntity");

            migrationBuilder.DropTable(
                name: "Nutricionistas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "MedidaEntity");
        }
    }
}
