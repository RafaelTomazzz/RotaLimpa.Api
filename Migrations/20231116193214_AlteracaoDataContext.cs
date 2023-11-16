using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoDataContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Empresa_EmpresaId",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_EmpresaId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Colaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_IdEmpresa",
                table: "Colaborador",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Empresa_IdEmpresa",
                table: "Colaborador",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Empresa_IdEmpresa",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_IdEmpresa",
                table: "Colaborador");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Colaborador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_EmpresaId",
                table: "Colaborador",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Empresa_EmpresaId",
                table: "Colaborador",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }
    }
}
