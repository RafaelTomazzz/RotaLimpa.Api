﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RotaLimpa.Api.Data;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231109005248_Ajuste")]
    partial class Ajuste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RotaLimpa.Api.Models.CEP", b =>
                {
                    b.Property<string>("Cep")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("Cep");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("Bairro");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("Cidade");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("Endereço");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("latitude");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Logradouro");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("longitude");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("CHAR")
                        .HasColumnName("UF");

                    b.HasKey("Cep");

                    b.ToTable("CEP");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DcColaborador")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("StColaborador")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DaEmpresa")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("Da_empresa")
                        .HasComment("DATA DA ULTIMA ALTERAÇÃO");

                    b.Property<string>("DcEmpresa")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)")
                        .HasColumnName("Dc_Empresa")
                        .HasComment("CNPJ");

                    b.Property<DateTime>("DiEmpresa")
                        .HasColumnType("datetime2")
                        .HasColumnName("Di_empresa")
                        .HasComment("DATA DE INCLUSÃO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("StEmpresa")
                        .HasColumnType("int")
                        .HasColumnName("St_empresa")
                        .HasComment("SITUAÇÃO DA EMPRESA");

                    b.HasKey("Id");

                    b.HasIndex("DcEmpresa")
                        .IsUnique();

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Frota", b =>
                {
                    b.Property<int>("Id_Veiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Veiculo"));

                    b.Property<DateTime>("DiVeiculo")
                        .HasColumnType("datetime2")
                        .HasColumnName("Di_Veiculo");

                    b.Property<string>("PVeiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("P_Veiculo");

                    b.Property<string>("StVeiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("St_Veiculo");

                    b.Property<double>("TmnVeiculo")
                        .HasColumnType("float")
                        .HasColumnName("Tmn_Veiculo")
                        .HasComment("Tamanho do veículo");

                    b.HasKey("Id_Veiculo");

                    b.ToTable("Frota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Kilometragem", b =>
                {
                    b.Property<int>("Id_Veiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Veiculo"));

                    b.Property<DateTime>("DiKilometragem")
                        .HasColumnType("datetime2")
                        .HasColumnName("Di_Kilometragem")
                        .HasComment("Data de início marcação");

                    b.Property<int?>("FrotaId_Veiculo")
                        .HasColumnType("int");

                    b.Property<int>("Km")
                        .HasColumnType("int")
                        .HasColumnName("Km")
                        .HasComment("Kilometragem do veículo");

                    b.Property<string>("SeKilometragem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Se_Kilometragem")
                        .HasComment("Sentido da Marcação");

                    b.HasKey("Id_Veiculo");

                    b.HasIndex("FrotaId_Veiculo");

                    b.ToTable("Kilometragem");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Motorista", b =>
                {
                    b.Property<int>("IdMotorista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMotorista"));

                    b.Property<DateTime>("Dc_Motorista")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dc_Motorista")
                        .HasComment("Data de criação do Motorista");

                    b.Property<string>("NomeMotorista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nm_Motorista")
                        .HasComment("Nome do motorista");

                    b.Property<string>("StMotorista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("St_Motorista");

                    b.HasKey("IdMotorista");

                    b.ToTable("Motorista");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Ocorrencia", b =>
                {
                    b.Property<int>("IdOcorrencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOcorrencia"));

                    b.Property<int>("IdTrajeto")
                        .HasColumnType("int")
                        .HasColumnName("Id_Trajeto");

                    b.Property<DateTime>("MtOcorrencia")
                        .HasColumnType("datetime2")
                        .HasColumnName("MtOcorrencia")
                        .HasComment("Data domento da ocorr�ncia");

                    b.Property<int>("TipoOcorrencia")
                        .HasColumnType("int");

                    b.HasKey("IdOcorrencia");

                    b.HasIndex("IdOcorrencia")
                        .IsUnique();

                    b.HasIndex("IdTrajeto");

                    b.ToTable("Ocorrencia");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Periodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DsPeriodo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ds_Periodo");

                    b.Property<string>("MfPeriodo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Mf_Periodo");

                    b.Property<string>("MiPeriodo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Mi_Periodo");

                    b.HasKey("Id");

                    b.ToTable("Periodo");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rota", b =>
                {
                    b.Property<int>("IdRota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRota"));

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<int>("DtRota")
                        .HasColumnType("int")
                        .HasColumnName("Dt_Rota")
                        .HasComment("Distancia da Rota");

                    b.Property<int>("IdPeriodo")
                        .HasColumnType("int");

                    b.Property<int>("SetorId")
                        .HasColumnType("int");

                    b.Property<int>("TmRota")
                        .HasColumnType("int")
                        .HasColumnName("Tm_Rota")
                        .HasComment("Tempo médio da Rota");

                    b.HasKey("IdRota");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("IdPeriodo");

                    b.HasIndex("SetorId");

                    b.ToTable("Rota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rua", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("RotaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Cep");

                    b.HasIndex("RotaId");

                    b.ToTable("Rua");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DaSetor")
                        .HasColumnType("datetime2")
                        .HasColumnName("Da_Setor");

                    b.Property<DateTime>("DiSetor")
                        .HasColumnType("datetime2")
                        .HasColumnName("Di_Setor");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("StSetor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("St_Setor");

                    b.Property<int>("TipoServico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.SetorVeiculo", b =>
                {
                    b.Property<int>("IdSetor")
                        .HasColumnType("int");

                    b.Property<int>("IdFrota")
                        .HasColumnType("int");

                    b.HasKey("IdSetor");

                    b.ToTable("SetorVeiculo");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Trajeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("IdFrota")
                        .HasColumnType("int");

                    b.Property<int>("IdMotorista")
                        .HasColumnType("int");

                    b.Property<int>("IdRota")
                        .HasColumnType("int");

                    b.Property<DateTime>("MiTrajeto")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mi_Trajeto")
                        .HasComment("Momento de início do trajeto");

                    b.Property<DateTime>("MjTrajeto")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mj_Trajeto")
                        .HasComment("Momento do fim do trajeto");

                    b.HasKey("Id");

                    b.HasIndex("IdMotorista");

                    b.HasIndex("IdRota");

                    b.ToTable("Trajeto");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Colaborador", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Empresa", "Empresa")
                        .WithMany("Colaboradores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Kilometragem", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Frota", "Frota")
                        .WithMany()
                        .HasForeignKey("FrotaId_Veiculo");

                    b.Navigation("Frota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Ocorrencia", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Trajeto", "Trajeto")
                        .WithMany()
                        .HasForeignKey("IdTrajeto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trajeto");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rota", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Colaborador", "Colaborador")
                        .WithMany("Rotas")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Periodo", "Periodo")
                        .WithMany("Rotas")
                        .HasForeignKey("IdPeriodo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Setor", "Setor")
                        .WithMany("Rotas")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Periodo");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rua", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.CEP", "CEP")
                        .WithMany("Ruas")
                        .HasForeignKey("Cep")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Rota", "Rota")
                        .WithMany("Ruas")
                        .HasForeignKey("RotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CEP");

                    b.Navigation("Rota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Setor", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Colaborador", "Colaborador")
                        .WithMany("Setores")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Empresa", "Empresa")
                        .WithMany("Setores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.SetorVeiculo", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("IdSetor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Trajeto", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Frota", "Frota")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Motorista", "Motorista")
                        .WithMany()
                        .HasForeignKey("IdMotorista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Rota", "Rota")
                        .WithMany()
                        .HasForeignKey("IdRota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Frota");

                    b.Navigation("Motorista");

                    b.Navigation("Rota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.CEP", b =>
                {
                    b.Navigation("Ruas");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Colaborador", b =>
                {
                    b.Navigation("Rotas");

                    b.Navigation("Setores");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Empresa", b =>
                {
                    b.Navigation("Colaboradores");

                    b.Navigation("Setores");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Periodo", b =>
                {
                    b.Navigation("Rotas");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rota", b =>
                {
                    b.Navigation("Ruas");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Setor", b =>
                {
                    b.Navigation("Rotas");
                });
#pragma warning restore 612, 618
        }
    }
}
