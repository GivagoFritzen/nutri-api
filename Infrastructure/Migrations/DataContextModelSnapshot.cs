﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entity.MedidaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Altura")
                        .HasColumnType("real");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PesoAtual")
                        .HasColumnType("real");

                    b.Property<float>("PesoIdeal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("MedidaEntity");
                });

            modelBuilder.Entity("Domain.Entity.Medidas.CircunferenciasEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Abdomen")
                        .HasColumnType("real");

                    b.Property<float>("AntebracoDireito")
                        .HasColumnType("real");

                    b.Property<float>("AntebracoEsquerdo")
                        .HasColumnType("real");

                    b.Property<float>("BracoContraidoDireito")
                        .HasColumnType("real");

                    b.Property<float>("BracoContraidoEsquerdo")
                        .HasColumnType("real");

                    b.Property<float>("BracoRelaxadoDireito")
                        .HasColumnType("real");

                    b.Property<float>("BracoRelaxadoEsquerdo")
                        .HasColumnType("real");

                    b.Property<float>("Cintura")
                        .HasColumnType("real");

                    b.Property<float>("CoxaDireita")
                        .HasColumnType("real");

                    b.Property<float>("CoxaEsquerda")
                        .HasColumnType("real");

                    b.Property<float>("CoxaProximalDireita")
                        .HasColumnType("real");

                    b.Property<float>("CoxaProximalEsquerda")
                        .HasColumnType("real");

                    b.Property<Guid?>("MedidaEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Ombro")
                        .HasColumnType("real");

                    b.Property<float>("PanturrilhaDireita")
                        .HasColumnType("real");

                    b.Property<float>("PanturrilhaEsquerda")
                        .HasColumnType("real");

                    b.Property<float>("Peitoral")
                        .HasColumnType("real");

                    b.Property<float>("Pescoso")
                        .HasColumnType("real");

                    b.Property<float>("PunhoDireito")
                        .HasColumnType("real");

                    b.Property<float>("PunhoEsquerdo")
                        .HasColumnType("real");

                    b.Property<float>("Quadril")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("MedidaEntityId");

                    b.ToTable("CircunferenciasEntity");
                });

            modelBuilder.Entity("Domain.Entity.NutricionistaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sexo")
                        .HasColumnType("bit");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nutricionistas");
                });

            modelBuilder.Entity("Domain.Entity.PacienteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MedidasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sexo")
                        .HasColumnType("bit");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedidasId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Domain.Entity.Medidas.CircunferenciasEntity", b =>
                {
                    b.HasOne("Domain.Entity.MedidaEntity", null)
                        .WithMany("Circunferencias")
                        .HasForeignKey("MedidaEntityId");
                });

            modelBuilder.Entity("Domain.Entity.PacienteEntity", b =>
                {
                    b.HasOne("Domain.Entity.MedidaEntity", "Medidas")
                        .WithMany()
                        .HasForeignKey("MedidasId");

                    b.Navigation("Medidas");
                });

            modelBuilder.Entity("Domain.Entity.MedidaEntity", b =>
                {
                    b.Navigation("Circunferencias");
                });
#pragma warning restore 612, 618
        }
    }
}
