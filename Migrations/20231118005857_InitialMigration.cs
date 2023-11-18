using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CEP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Endereço = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UF = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Dc_Empresa = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false, comment: "CNPJ"),
                    St_empresa = table.Column<int>(type: "int", nullable: false, comment: "SITUAÇÃO DA EMPRESA"),
                    Di_empresa = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "DATA DE INCLUSÃO"),
                    Da_empresa = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "DATA DA ULTIMA ALTERAÇÃO")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Veiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tmn_Veiculo = table.Column<double>(type: "float", nullable: false, comment: "Tamanho do ve�culo"),
                    Di_Veiculo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    St_Veiculo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Primeiro_Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sobre_Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Di_Motorista = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de cria��o do Motorista"),
                    St_Motorista = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RG = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ds_Periodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mi_Periodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mf_Periodo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    Primeiro_Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sobre_Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Di_Colaborador = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de inserção do Colaborador"),
                    St_Colaborador = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RG = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborador_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kilometragem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false, comment: "Kilometragem do veículo"),
                    Di_Kilometragem = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de início marcação")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kilometragem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kilometragem_Frota_Id",
                        column: x => x.Id,
                        principalTable: "Frota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoLonginMotorista",
                columns: table => new
                {
                    Historico_Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMotorista = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoLonginMotorista", x => x.Historico_Login);
                    table.ForeignKey(
                        name: "FK_HistoLonginMotorista_Motorista_IdMotorista",
                        column: x => x.IdMotorista,
                        principalTable: "Motorista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoLonginColaborador",
                columns: table => new
                {
                    Historico_Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdColaborador = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoLonginColaborador", x => x.Historico_Login);
                    table.ForeignKey(
                        name: "FK_HistoLonginColaborador_Colaborador_IdColaborador",
                        column: x => x.IdColaborador,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColaborador = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    TipoServico = table.Column<int>(type: "int", nullable: false),
                    Di_Setor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Da_Setor = table.Column<DateTime>(type: "datetime2", nullable: true),
                    St_Setor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setor_Colaborador_IdColaborador",
                        column: x => x.IdColaborador,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Setor_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColaborador = table.Column<int>(type: "int", nullable: false),
                    IdPeriodo = table.Column<int>(type: "int", nullable: false),
                    PeriodoId = table.Column<int>(type: "int", nullable: true),
                    IdSetor = table.Column<int>(type: "int", nullable: false),
                    Dt_Rota = table.Column<int>(type: "int", nullable: false, comment: "Distancia da Rota"),
                    Tm_Rota = table.Column<int>(type: "int", nullable: false, comment: "Tempo médio da Rota")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rota_Colaborador_IdColaborador",
                        column: x => x.IdColaborador,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rota_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rota_Setor_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SetorVeiculo",
                columns: table => new
                {
                    IdSetor = table.Column<int>(type: "int", nullable: false),
                    IdFrota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetorVeiculo", x => new { x.IdSetor, x.IdFrota });
                    table.ForeignKey(
                        name: "FK_SetorVeiculo_Frota_IdFrota",
                        column: x => x.IdFrota,
                        principalTable: "Frota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetorVeiculo_Setor_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCep = table.Column<int>(type: "int", nullable: false),
                    IdRota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rua_CEP_IdCep",
                        column: x => x.IdCep,
                        principalTable: "CEP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rua_Rota_IdRota",
                        column: x => x.IdRota,
                        principalTable: "Rota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trajeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMotorista = table.Column<int>(type: "int", nullable: false),
                    IdRota = table.Column<int>(type: "int", nullable: false),
                    IdPeriodo = table.Column<int>(type: "int", nullable: false),
                    IdFrota = table.Column<int>(type: "int", nullable: false),
                    Mi_Trajeto = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Momento de início do trajeto"),
                    Mj_Trajeto = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Momento do fim do trajeto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trajeto_Frota_IdFrota",
                        column: x => x.IdFrota,
                        principalTable: "Frota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trajeto_Motorista_IdMotorista",
                        column: x => x.IdMotorista,
                        principalTable: "Motorista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trajeto_Periodo_IdPeriodo",
                        column: x => x.IdPeriodo,
                        principalTable: "Periodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trajeto_Rota_IdRota",
                        column: x => x.IdRota,
                        principalTable: "Rota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Trajeto = table.Column<int>(type: "int", nullable: false),
                    TipoOcorrencia = table.Column<int>(type: "int", nullable: false),
                    MtOcorrencia = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data domento da ocorr�ncia")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Trajeto_Id_Trajeto",
                        column: x => x.Id_Trajeto,
                        principalTable: "Trajeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatorioFinal",
                columns: table => new
                {
                    Id_Relatorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSetor = table.Column<int>(type: "int", nullable: false),
                    IdOcorrencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioFinal", x => x.Id_Relatorio);
                    table.ForeignKey(
                        name: "FK_RelatorioFinal_Ocorrencia_IdOcorrencia",
                        column: x => x.IdOcorrencia,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatorioFinal_Setor_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_Id",
                table: "Colaborador",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_IdEmpresa",
                table: "Colaborador",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Dc_Empresa",
                table: "Empresa",
                column: "Dc_Empresa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoLonginColaborador_IdColaborador",
                table: "HistoLonginColaborador",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_HistoLonginMotorista_IdMotorista",
                table: "HistoLonginMotorista",
                column: "IdMotorista");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_Id",
                table: "Ocorrencia",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_Id_Trajeto",
                table: "Ocorrencia",
                column: "Id_Trajeto");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioFinal_IdOcorrencia",
                table: "RelatorioFinal",
                column: "IdOcorrencia");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioFinal_IdSetor",
                table: "RelatorioFinal",
                column: "IdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Rota_IdColaborador",
                table: "Rota",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Rota_IdSetor",
                table: "Rota",
                column: "IdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Rota_PeriodoId",
                table: "Rota",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Rua_IdCep",
                table: "Rua",
                column: "IdCep");

            migrationBuilder.CreateIndex(
                name: "IX_Rua_IdRota",
                table: "Rua",
                column: "IdRota");

            migrationBuilder.CreateIndex(
                name: "IX_Setor_IdColaborador",
                table: "Setor",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Setor_IdEmpresa",
                table: "Setor",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_SetorVeiculo_IdFrota",
                table: "SetorVeiculo",
                column: "IdFrota");

            migrationBuilder.CreateIndex(
                name: "IX_Trajeto_IdFrota",
                table: "Trajeto",
                column: "IdFrota");

            migrationBuilder.CreateIndex(
                name: "IX_Trajeto_IdMotorista",
                table: "Trajeto",
                column: "IdMotorista");

            migrationBuilder.CreateIndex(
                name: "IX_Trajeto_IdPeriodo",
                table: "Trajeto",
                column: "IdPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_Trajeto_IdRota",
                table: "Trajeto",
                column: "IdRota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoLonginColaborador");

            migrationBuilder.DropTable(
                name: "HistoLonginMotorista");

            migrationBuilder.DropTable(
                name: "Kilometragem");

            migrationBuilder.DropTable(
                name: "RelatorioFinal");

            migrationBuilder.DropTable(
                name: "Rua");

            migrationBuilder.DropTable(
                name: "SetorVeiculo");

            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "CEP");

            migrationBuilder.DropTable(
                name: "Trajeto");

            migrationBuilder.DropTable(
                name: "Frota");

            migrationBuilder.DropTable(
                name: "Motorista");

            migrationBuilder.DropTable(
                name: "Rota");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
