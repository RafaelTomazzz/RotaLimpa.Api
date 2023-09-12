using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
