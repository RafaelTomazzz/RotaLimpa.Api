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
                    table.PrimaryKey("PK_CEP", x => x.Cep);
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
                    Tmn_Veiculo = table.Column<double>(type: "float", nullable: false, comment: "Tamanho do veículo"),
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
                    Nm_Motorista = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Nome do motorista"),
                    Dc_Motorista = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do Motorista"),
                    St_Motorista = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DcColaborador = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    StColaborador = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborador_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kilometragem",
                columns: table => new
                {
                    Id_Veiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrotaId_Veiculo = table.Column<int>(type: "int", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false, comment: "Kilometragem do veículo"),
                    Se_Kilometragem = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Sentido da Marcação"),
                    Di_Kilometragem = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de início marcação")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kilometragem", x => x.Id_Veiculo);
                    table.ForeignKey(
                        name: "FK_Kilometragem_Frota_FrotaId_Veiculo",
                        column: x => x.FrotaId_Veiculo,
                        principalTable: "Frota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    TipoServico = table.Column<int>(type: "int", nullable: false),
                    Di_Setor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Da_Setor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    St_Setor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setor_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Setor_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    IdPeriodo = table.Column<int>(type: "int", nullable: false),
                    SetorId = table.Column<int>(type: "int", nullable: false),
                    Dt_Rota = table.Column<int>(type: "int", nullable: false, comment: "Distancia da Rota"),
                    Tm_Rota = table.Column<int>(type: "int", nullable: false, comment: "Tempo médio da Rota")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rota_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rota_Periodo_IdPeriodo",
                        column: x => x.IdPeriodo,
                        principalTable: "Periodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rota_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SetorVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdFrota = table.Column<int>(type: "int", nullable: false),
                    FrotaId_Veiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetorVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetorVeiculo_Frota_FrotaId_Veiculo",
                        column: x => x.FrotaId_Veiculo,
                        principalTable: "Frota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetorVeiculo_Setor_Id",
                        column: x => x.Id,
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
                    Cep = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    RotaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rua_CEP_Cep",
                        column: x => x.Cep,
                        principalTable: "CEP",
                        principalColumn: "Cep",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rua_Rota_RotaId",
                        column: x => x.RotaId,
                        principalTable: "Rota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trajeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdMotorista = table.Column<int>(type: "int", nullable: false),
                    IdRota = table.Column<int>(type: "int", nullable: false),
                    IdFrota = table.Column<int>(type: "int", nullable: false),
                    Mi_Trajeto = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Momento de início do trajeto"),
                    Mj_Trajeto = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Momento do fim do trajeto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trajeto_Frota_Id",
                        column: x => x.Id,
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

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_EmpresaId",
                table: "Colaborador",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_Id",
                table: "Colaborador",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Dc_Empresa",
                table: "Empresa",
                column: "Dc_Empresa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kilometragem_FrotaId_Veiculo",
                table: "Kilometragem",
                column: "FrotaId_Veiculo");

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
                name: "IX_Rota_ColaboradorId",
                table: "Rota",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rota_IdPeriodo",
                table: "Rota",
                column: "IdPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_Rota_SetorId",
                table: "Rota",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rua_Cep",
                table: "Rua",
                column: "Cep");

            migrationBuilder.CreateIndex(
                name: "IX_Rua_RotaId",
                table: "Rua",
                column: "RotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Setor_ColaboradorId",
                table: "Setor",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Setor_EmpresaId",
                table: "Setor",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_SetorVeiculo_FrotaId_Veiculo",
                table: "SetorVeiculo",
                column: "FrotaId_Veiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Trajeto_IdMotorista",
                table: "Trajeto",
                column: "IdMotorista");

            migrationBuilder.CreateIndex(
                name: "IX_Trajeto_IdRota",
                table: "Trajeto",
                column: "IdRota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kilometragem");

            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "Rua");

            migrationBuilder.DropTable(
                name: "SetorVeiculo");

            migrationBuilder.DropTable(
                name: "Trajeto");

            migrationBuilder.DropTable(
                name: "CEP");

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
