using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationRuaCepFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CEP",
                columns: table => new
                {
                    Cep = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEP", x => x.Cep);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    dc_empresa = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false, comment: "CNPJ"),
                    st_empresa = table.Column<int>(type: "int", nullable: false, comment: "SITUAÇÃO DA EMPRESA"),
                    di_empresa = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "DATA DE INCLUSÃO"),
                    da_empresa = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "DATA DA ULTIMA ALTERAÇÃO")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frotas",
                columns: table => new
                {
                    Id_Veiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Veiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tmn_Veiculo = table.Column<float>(type: "real", nullable: false),
                    Di_Veiculo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    St_Veiculo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frotas", x => x.Id_Veiculo);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id_Motorista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm_Motorista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dc_Motorista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    St_Motorista = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id_Motorista);
                });

            migrationBuilder.CreateTable(
                name: "Periodos",
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
                    table.PrimaryKey("PK_Periodos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ruas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ruas_CEP_Cep1",
                        column: x => x.Cep1,
                        principalTable: "CEP",
                        principalColumn: "Cep");
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa_Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    dbColaborador = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    stColaborador = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Colaboradores_Empresas_Empresa_Id",
                        column: x => x.Empresa_Id,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kilometragens",
                columns: table => new
                {
                    Id_Veiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrotaId_Veiculo = table.Column<int>(type: "int", nullable: false),
                    Kilometragem = table.Column<int>(type: "int", nullable: false),
                    seKilometragem = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Sentido da Marcação"),
                    diKilometragem = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de início marcação")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kilometragens", x => x.Id_Veiculo);
                    table.ForeignKey(
                        name: "FK_Kilometragens_Frotas_FrotaId_Veiculo",
                        column: x => x.FrotaId_Veiculo,
                        principalTable: "Frotas",
                        principalColumn: "Id_Veiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Colaborador = table.Column<int>(type: "int", nullable: false),
                    Id_Empresa = table.Column<int>(type: "int", nullable: false),
                    TipoServico = table.Column<int>(type: "int", nullable: false),
                    Di_Setor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Da_Setor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    St_Setor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setores_Colaboradores_Id_Colaborador",
                        column: x => x.Id_Colaborador,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Setores_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Setores_Empresas_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rotas",
                columns: table => new
                {
                    IdRota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Colaborador = table.Column<int>(type: "int", nullable: false),
                    Id_Periodo = table.Column<int>(type: "int", nullable: false),
                    Id_Setor = table.Column<int>(type: "int", nullable: false),
                    dtRota = table.Column<int>(type: "int", nullable: false, comment: "Distancia da Rota"),
                    tmRota = table.Column<int>(type: "int", nullable: false, comment: "Tempo médio da Rota"),
                    SetorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotas", x => x.IdRota);
                    table.ForeignKey(
                        name: "FK_Rotas_Colaboradores_Id_Colaborador",
                        column: x => x.Id_Colaborador,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rotas_Periodos_Id_Periodo",
                        column: x => x.Id_Periodo,
                        principalTable: "Periodos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rotas_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SetorVeiculos",
                columns: table => new
                {
                    Id_Setor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetorId = table.Column<int>(type: "int", nullable: false),
                    Id_Veiculo = table.Column<int>(type: "int", nullable: false),
                    FrotaId_Veiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetorVeiculos", x => x.Id_Setor);
                    table.ForeignKey(
                        name: "FK_SetorVeiculos_Frotas_FrotaId_Veiculo",
                        column: x => x.FrotaId_Veiculo,
                        principalTable: "Frotas",
                        principalColumn: "Id_Veiculo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetorVeiculos_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trajetos",
                columns: table => new
                {
                    idTrajeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Motorista1 = table.Column<int>(type: "int", nullable: false),
                    Id_RotaId = table.Column<int>(type: "int", nullable: false),
                    Id_Veiculo1 = table.Column<int>(type: "int", nullable: false),
                    Mi_Trajeto = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Momento de início do trajeto"),
                    Mj_Trajeto = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Momento do fim do trajeto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajetos", x => x.idTrajeto);
                    table.ForeignKey(
                        name: "FK_Trajetos_Frotas_Id_Veiculo1",
                        column: x => x.Id_Veiculo1,
                        principalTable: "Frotas",
                        principalColumn: "Id_Veiculo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trajetos_Motoristas_Id_Motorista1",
                        column: x => x.Id_Motorista1,
                        principalTable: "Motoristas",
                        principalColumn: "Id_Motorista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trajetos_Rotas_Id_RotaId",
                        column: x => x.Id_RotaId,
                        principalTable: "Rotas",
                        principalColumn: "IdRota",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    IdOcorrencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_TrajetoId = table.Column<int>(type: "int", nullable: false),
                    Tipo_Ocorrencia = table.Column<int>(type: "int", nullable: false),
                    mtOcorrencia = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Momento da ocorrencia")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.IdOcorrencia);
                    table.ForeignKey(
                        name: "FK_Ocorrencias_Trajetos_Id_TrajetoId",
                        column: x => x.Id_TrajetoId,
                        principalTable: "Trajetos",
                        principalColumn: "idTrajeto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_Empresa_Id",
                table: "Colaboradores",
                column: "Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_EmpresaId",
                table: "Colaboradores",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_Id",
                table: "Colaboradores",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_dc_empresa",
                table: "Empresas",
                column: "dc_empresa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kilometragens_FrotaId_Veiculo",
                table: "Kilometragens",
                column: "FrotaId_Veiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_Id_TrajetoId",
                table: "Ocorrencias",
                column: "Id_TrajetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_IdOcorrencia",
                table: "Ocorrencias",
                column: "IdOcorrencia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_Id_Colaborador",
                table: "Rotas",
                column: "Id_Colaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_Id_Periodo",
                table: "Rotas",
                column: "Id_Periodo");

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_SetorId",
                table: "Rotas",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ruas_Cep1",
                table: "Ruas",
                column: "Cep1");

            migrationBuilder.CreateIndex(
                name: "IX_Setores_EmpresaId",
                table: "Setores",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Setores_Id_Colaborador",
                table: "Setores",
                column: "Id_Colaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Setores_Id_Empresa",
                table: "Setores",
                column: "Id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_SetorVeiculos_FrotaId_Veiculo",
                table: "SetorVeiculos",
                column: "FrotaId_Veiculo");

            migrationBuilder.CreateIndex(
                name: "IX_SetorVeiculos_SetorId",
                table: "SetorVeiculos",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Trajetos_Id_Motorista1",
                table: "Trajetos",
                column: "Id_Motorista1");

            migrationBuilder.CreateIndex(
                name: "IX_Trajetos_Id_RotaId",
                table: "Trajetos",
                column: "Id_RotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Trajetos_Id_Veiculo1",
                table: "Trajetos",
                column: "Id_Veiculo1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kilometragens");

            migrationBuilder.DropTable(
                name: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "Ruas");

            migrationBuilder.DropTable(
                name: "SetorVeiculos");

            migrationBuilder.DropTable(
                name: "Trajetos");

            migrationBuilder.DropTable(
                name: "CEP");

            migrationBuilder.DropTable(
                name: "Frotas");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Rotas");

            migrationBuilder.DropTable(
                name: "Periodos");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
