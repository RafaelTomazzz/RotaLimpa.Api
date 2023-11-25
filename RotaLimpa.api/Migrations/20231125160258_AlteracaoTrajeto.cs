using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoTrajeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatorioFinal_Ocorrencia_IdOcorrencia",
                table: "RelatorioFinal");

            migrationBuilder.RenameColumn(
                name: "IdOcorrencia",
                table: "RelatorioFinal",
                newName: "IdTrajeto");

            migrationBuilder.RenameIndex(
                name: "IX_RelatorioFinal_IdOcorrencia",
                table: "RelatorioFinal",
                newName: "IX_RelatorioFinal_IdTrajeto");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatorioFinal_Trajeto_IdTrajeto",
                table: "RelatorioFinal",
                column: "IdTrajeto",
                principalTable: "Trajeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatorioFinal_Trajeto_IdTrajeto",
                table: "RelatorioFinal");

            migrationBuilder.RenameColumn(
                name: "IdTrajeto",
                table: "RelatorioFinal",
                newName: "IdOcorrencia");

            migrationBuilder.RenameIndex(
                name: "IX_RelatorioFinal_IdTrajeto",
                table: "RelatorioFinal",
                newName: "IX_RelatorioFinal_IdOcorrencia");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatorioFinal_Ocorrencia_IdOcorrencia",
                table: "RelatorioFinal",
                column: "IdOcorrencia",
                principalTable: "Ocorrencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
