using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CircuferenciaEntity",
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
                    Pescoco = table.Column<float>(type: "real", nullable: false),
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
                    CoxaProximalEsquerda = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircuferenciaEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutricionistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NutricionistaEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Nutricionistas_NutricionistaEntityId",
                        column: x => x.NutricionistaEntityId,
                        principalTable: "Nutricionistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedidaEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesoAtual = table.Column<float>(type: "real", nullable: false),
                    PesoIdeal = table.Column<float>(type: "real", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedidaEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedidaEntity_CircuferenciaEntity_CircunferenciaId",
                        column: x => x.CircunferenciaId,
                        principalTable: "CircuferenciaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedidaEntity_Pacientes_PacienteEntityId",
                        column: x => x.PacienteEntityId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanoAlimentarEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoAlimentarEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoAlimentarEntity_Pacientes_PacienteEntityId",
                        column: x => x.PacienteEntityId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefeicaoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoAlimentarEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefeicaoEntity_PlanoAlimentarEntity_PlanoAlimentarEntityId",
                        column: x => x.PlanoAlimentarEntityId,
                        principalTable: "PlanoAlimentarEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlimentoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefeicaoEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medida = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlimentoEntity_RefeicaoEntity_RefeicaoEntityId",
                        column: x => x.RefeicaoEntityId,
                        principalTable: "RefeicaoEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentoEntity_RefeicaoEntityId",
                table: "AlimentoEntity",
                column: "RefeicaoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MedidaEntity_CircunferenciaId",
                table: "MedidaEntity",
                column: "CircunferenciaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedidaEntity_PacienteEntityId",
                table: "MedidaEntity",
                column: "PacienteEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_NutricionistaEntityId",
                table: "Pacientes",
                column: "NutricionistaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAlimentarEntity_PacienteEntityId",
                table: "PlanoAlimentarEntity",
                column: "PacienteEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RefeicaoEntity_PlanoAlimentarEntityId",
                table: "RefeicaoEntity",
                column: "PlanoAlimentarEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentoEntity");

            migrationBuilder.DropTable(
                name: "MedidaEntity");

            migrationBuilder.DropTable(
                name: "RefeicaoEntity");

            migrationBuilder.DropTable(
                name: "CircuferenciaEntity");

            migrationBuilder.DropTable(
                name: "PlanoAlimentarEntity");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Nutricionistas");
        }
    }
}
