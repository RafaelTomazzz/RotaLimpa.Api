using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class _213011 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "OcorrenciaId",
                table: "RelatorioFinal",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Cep",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "P_Veiculo",
                table: "Frota",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                comment: "placa do veiculo",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "placa do veiculo");

            migrationBuilder.AlterColumn<string>(
                name: "St_empresa",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: false,
                comment: "SITUAÇÃO DA EMPRESA",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "SITUAÇÃO DA EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioFinal_OcorrenciaId",
                table: "RelatorioFinal",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_Id_Cep",
                table: "Ocorrencia",
                column: "Id_Cep");

            migrationBuilder.CreateIndex(
                name: "IX_Motorista_Id",
                table: "Motorista",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_CEP_Id_Cep",
                table: "Ocorrencia",
                column: "Id_Cep",
                principalTable: "CEP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatorioFinal_Ocorrencia_OcorrenciaId",
                table: "RelatorioFinal",
                column: "OcorrenciaId",
                principalTable: "Ocorrencia",
                principalColumn: "Id");

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
                name: "FK_Ocorrencia_CEP_Id_Cep",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatorioFinal_Ocorrencia_OcorrenciaId",
                table: "RelatorioFinal");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatorioFinal_Trajeto_IdTrajeto",
                table: "RelatorioFinal");

            migrationBuilder.DropIndex(
                name: "IX_RelatorioFinal_OcorrenciaId",
                table: "RelatorioFinal");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_Id_Cep",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Motorista_Id",
                table: "Motorista");

            migrationBuilder.DropColumn(
                name: "OcorrenciaId",
                table: "RelatorioFinal");

            migrationBuilder.DropColumn(
                name: "Id_Cep",
                table: "Ocorrencia");

            migrationBuilder.RenameColumn(
                name: "IdTrajeto",
                table: "RelatorioFinal",
                newName: "IdOcorrencia");

            migrationBuilder.RenameIndex(
                name: "IX_RelatorioFinal_IdTrajeto",
                table: "RelatorioFinal",
                newName: "IX_RelatorioFinal_IdOcorrencia");

            migrationBuilder.AlterColumn<string>(
                name: "P_Veiculo",
                table: "Frota",
                type: "nvarchar(max)",
                nullable: false,
                comment: "placa do veiculo",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldComment: "placa do veiculo");

            migrationBuilder.AlterColumn<int>(
                name: "St_empresa",
                table: "Empresa",
                type: "int",
                nullable: false,
                comment: "SITUAÇÃO DA EMPRESA",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "SITUAÇÃO DA EMPRESA");

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
