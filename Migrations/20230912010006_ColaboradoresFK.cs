using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class ColaboradoresFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Empresa_IdId",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpresasId",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_Empresa_IdId",
                table: "Colaboradores",
                column: "Empresa_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_EmpresasId",
                table: "Colaboradores",
                column: "EmpresasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Empresas_Empresa_IdId",
                table: "Colaboradores",
                column: "Empresa_IdId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Empresas_EmpresasId",
                table: "Colaboradores",
                column: "EmpresasId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Empresas_Empresa_IdId",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Empresas_EmpresasId",
                table: "Colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_Empresa_IdId",
                table: "Colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_EmpresasId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Empresa_IdId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "EmpresasId",
                table: "Colaboradores");
        }
    }
}
