using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Empresa_EmpresaId",
                table: "Colaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Empresa_EmpresaId",
                table: "Colaborador",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Empresa_EmpresaId",
                table: "Colaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Empresa_EmpresaId",
                table: "Colaborador",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
