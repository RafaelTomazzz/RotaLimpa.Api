using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class ColaboradoresMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    dbColaborador = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    stColaborador = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    id_Empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    nome_empresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome da empresa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.id_Empresa);
                });

            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Empresa = table.Column<int>(type: "int", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tipo_funcionario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.id_funcionario);
                    table.ForeignKey(
                        name: "FK_funcionario_Empresa_id_Empresa",
                        column: x => x.id_Empresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_id_Empresa",
                table: "funcionario",
                column: "id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_id_funcionario",
                table: "funcionario",
                column: "id_funcionario",
                unique: true);
        }
    }
}
