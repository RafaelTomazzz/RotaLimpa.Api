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
    [Migration("20231125012250_Correcao2")]
    partial class Correcao2
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("Bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("Cep");

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

                    b.HasKey("Id");

                    b.ToTable("CEP");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("Di_Colaborador")
                        .HasColumnType("datetime2")
                        .HasColumnName("Di_Colaborador")
                        .HasComment("Data de inserção do Colaborador");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnName("Login");

                    b.Property<string>("PNome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Primeiro_Nome");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("RG");

                    b.Property<string>("SNome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Sobre_Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Senha");

                    b.Property<string>("StColaborador")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("St_Colaborador");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdEmpresa");

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

                    b.Property<string>("StEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("St_empresa")
                        .HasComment("SITUAÇÃO DA EMPRESA");

                    b.HasKey("Id");

                    b.HasIndex("DcEmpresa")
                        .IsUnique();

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Frota", b =>
                {
                    b.Property<int>("IdVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVeiculo"));

                    b.Property<DateTime>("DiVeiculo")
                        .HasColumnType("datetime2")
                        .HasColumnName("Di_Veiculo");

                    b.Property<string>("PVeiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("P_Veiculo")
                        .HasComment("placa do veiculo");

                    b.Property<string>("StVeiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("St_Veiculo");

                    b.Property<double>("TmnVeiculo")
                        .HasColumnType("float")
                        .HasColumnName("Tmn_Veiculo")
                        .HasComment("Tamanho do ve�culo");

                    b.HasKey("IdVeiculo");

                    b.ToTable("Frota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.HisLoginC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Historico_Login");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdColaborador")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdColaborador");

                    b.ToTable("HistoLonginColaborador");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.HisLoginM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Historico_Login");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMotorista")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMotorista");

                    b.ToTable("HistoLonginMotorista");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Kilometragem", b =>
                {
                    b.Property<int>("IdVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTime>("DiKilometragem")
                        .HasColumnType("datetime2")
                        .HasColumnName("Di_Kilometragem")
                        .HasComment("Data de início marcação");

                    b.Property<int>("Km")
                        .HasColumnType("int")
                        .HasColumnName("Km")
                        .HasComment("Kilometragem do veículo");

                    b.HasKey("IdVeiculo");

                    b.ToTable("Kilometragem");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Motorista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("Di_Motorista")
                        .HasColumnType("datetime2")
                        .HasColumnName("Di_Motorista")
                        .HasComment("Data de cria��o do Motorista");

                    b.Property<string>("Login")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnName("Login");

                    b.Property<string>("PNome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Primeiro_Nome");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("RG");

                    b.Property<string>("SNome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Sobre_Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Senha");

                    b.Property<string>("StMotorista")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("St_Motorista");

                    b.HasKey("Id");

                    b.ToTable("Motorista");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Ocorrencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdTrajeto")
                        .HasColumnType("int")
                        .HasColumnName("Id_Trajeto");

                    b.Property<DateTime>("MtOcorrencia")
                        .HasColumnType("datetime2")
                        .HasColumnName("MtOcorrencia")
                        .HasComment("Data domento da ocorr�ncia");

                    b.Property<int>("TipoOcorrencia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
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

            modelBuilder.Entity("RotaLimpa.Api.Models.RelatorioFinal", b =>
                {
                    b.Property<int>("IdRelatorio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Relatorio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRelatorio"));

                    b.Property<int>("IdOcorrencia")
                        .HasColumnType("int");

                    b.Property<int>("IdSetor")
                        .HasColumnType("int");

                    b.HasKey("IdRelatorio");

                    b.HasIndex("IdOcorrencia");

                    b.HasIndex("IdSetor");

                    b.ToTable("RelatorioFinal");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DtRota")
                        .HasColumnType("int")
                        .HasColumnName("Dt_Rota")
                        .HasComment("Distancia da Rota");

                    b.Property<int>("IdColaborador")
                        .HasColumnType("int");

                    b.Property<int>("IdSetor")
                        .HasColumnType("int");

                    b.Property<int>("TmRota")
                        .HasColumnType("int")
                        .HasColumnName("Tm_Rota")
                        .HasComment("Tempo médio da Rota");

                    b.HasKey("Id");

                    b.HasIndex("IdColaborador");

                    b.HasIndex("IdSetor");

                    b.ToTable("Rota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rua", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCep")
                        .HasColumnType("int");

                    b.Property<int>("IdRota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCep");

                    b.HasIndex("IdRota");

                    b.ToTable("Rua");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DaSetor")
                        .HasColumnType("datetime2")
                        .HasColumnName("Da_Setor");

                    b.Property<DateTime>("DiSetor")
                        .HasColumnType("datetime2")
                        .HasColumnName("Di_Setor");

                    b.Property<int>("IdColaborador")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("StSetor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("St_Setor");

                    b.Property<int>("TipoServico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdColaborador");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.SetorVeiculo", b =>
                {
                    b.Property<int>("IdSetor")
                        .HasColumnType("int");

                    b.Property<int>("IdFrota")
                        .HasColumnType("int");

                    b.HasKey("IdSetor", "IdFrota");

                    b.HasIndex("IdFrota");

                    b.ToTable("SetorVeiculo");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Trajeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdFrota")
                        .HasColumnType("int");

                    b.Property<int>("IdMotorista")
                        .HasColumnType("int");

                    b.Property<int>("IdPeriodo")
                        .HasColumnType("int");

                    b.Property<int>("IdRota")
                        .HasColumnType("int");

                    b.Property<DateTime>("MfTrajeto")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mf_Trajeto")
                        .HasComment("Momento do fim do trajeto");

                    b.Property<DateTime>("MiTrajeto")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mi_Trajeto")
                        .HasComment("Momento de início do trajeto");

                    b.HasKey("Id");

                    b.HasIndex("IdFrota");

                    b.HasIndex("IdMotorista");

                    b.HasIndex("IdPeriodo");

                    b.HasIndex("IdRota");

                    b.ToTable("Trajeto");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Colaborador", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Empresa", "Empresa")
                        .WithMany("Colaboradores")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.HisLoginC", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Colaborador", "Colaborador")
                        .WithMany("HisLoginCs")
                        .HasForeignKey("IdColaborador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.HisLoginM", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Motorista", "Motorista")
                        .WithMany("HisLoginMs")
                        .HasForeignKey("IdMotorista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Kilometragem", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Frota", "Frota")
                        .WithOne("Kilometragem")
                        .HasForeignKey("RotaLimpa.Api.Models.Kilometragem", "IdVeiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Frota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Ocorrencia", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Trajeto", "Trajeto")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("IdTrajeto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trajeto");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.RelatorioFinal", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Ocorrencia", "Ocorrencia")
                        .WithMany("RelatoriosFinais")
                        .HasForeignKey("IdOcorrencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Setor", "Setor")
                        .WithMany("RelatoriosFinais")
                        .HasForeignKey("IdSetor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ocorrencia");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rota", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Colaborador", "Colaborador")
                        .WithMany("Rotas")
                        .HasForeignKey("IdColaborador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Setor", "Setor")
                        .WithMany("Rotas")
                        .HasForeignKey("IdSetor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rua", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.CEP", "CEP")
                        .WithMany("Ruas")
                        .HasForeignKey("IdCep")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Rota", "Rota")
                        .WithMany("Ruas")
                        .HasForeignKey("IdRota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CEP");

                    b.Navigation("Rota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Setor", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Colaborador", "Colaborador")
                        .WithMany("Setores")
                        .HasForeignKey("IdColaborador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Empresa", "Empresa")
                        .WithMany("Setores")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.SetorVeiculo", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Frota", "Frota")
                        .WithMany("SetorVeiculos")
                        .HasForeignKey("IdFrota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Setor", "Setor")
                        .WithMany("SetorVeiculos")
                        .HasForeignKey("IdSetor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Frota");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Trajeto", b =>
                {
                    b.HasOne("RotaLimpa.Api.Models.Frota", "Frota")
                        .WithMany("Trajetos")
                        .HasForeignKey("IdFrota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Motorista", "Motorista")
                        .WithMany("Trajetos")
                        .HasForeignKey("IdMotorista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Periodo", "Periodo")
                        .WithMany("Trajetos")
                        .HasForeignKey("IdPeriodo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotaLimpa.Api.Models.Rota", "Rota")
                        .WithMany("Trajetos")
                        .HasForeignKey("IdRota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Frota");

                    b.Navigation("Motorista");

                    b.Navigation("Periodo");

                    b.Navigation("Rota");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.CEP", b =>
                {
                    b.Navigation("Ruas");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Colaborador", b =>
                {
                    b.Navigation("HisLoginCs");

                    b.Navigation("Rotas");

                    b.Navigation("Setores");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Empresa", b =>
                {
                    b.Navigation("Colaboradores");

                    b.Navigation("Setores");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Frota", b =>
                {
                    b.Navigation("Kilometragem");

                    b.Navigation("SetorVeiculos");

                    b.Navigation("Trajetos");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Motorista", b =>
                {
                    b.Navigation("HisLoginMs");

                    b.Navigation("Trajetos");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Ocorrencia", b =>
                {
                    b.Navigation("RelatoriosFinais");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Periodo", b =>
                {
                    b.Navigation("Trajetos");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Rota", b =>
                {
                    b.Navigation("Ruas");

                    b.Navigation("Trajetos");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Setor", b =>
                {
                    b.Navigation("RelatoriosFinais");

                    b.Navigation("Rotas");

                    b.Navigation("SetorVeiculos");
                });

            modelBuilder.Entity("RotaLimpa.Api.Models.Trajeto", b =>
                {
                    b.Navigation("Ocorrencias");
                });
#pragma warning restore 612, 618
        }
    }
}
