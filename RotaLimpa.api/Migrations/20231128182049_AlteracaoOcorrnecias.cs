using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoOcorrnecias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_CEP_IdCep",
                table: "Ocorrencia");

            migrationBuilder.RenameColumn(
                name: "IdCep",
                table: "Ocorrencia",
                newName: "Id_Cep");

            migrationBuilder.RenameIndex(
                name: "IX_Ocorrencia_IdCep",
                table: "Ocorrencia",
                newName: "IX_Ocorrencia_Id_Cep");

            migrationBuilder.AddColumn<int>(
                name: "CEPId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_CEPId",
                table: "Ocorrencia",
                column: "CEPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_CEP_CEPId",
                table: "Ocorrencia",
                column: "CEPId",
                principalTable: "CEP",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_CEP_Id_Cep",
                table: "Ocorrencia",
                column: "Id_Cep",
                principalTable: "CEP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_CEP_CEPId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_CEP_Id_Cep",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_CEPId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "CEPId",
                table: "Ocorrencia");

            migrationBuilder.RenameColumn(
                name: "Id_Cep",
                table: "Ocorrencia",
                newName: "IdCep");

            migrationBuilder.RenameIndex(
                name: "IX_Ocorrencia_Id_Cep",
                table: "Ocorrencia",
                newName: "IX_Ocorrencia_IdCep");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_CEP_IdCep",
                table: "Ocorrencia",
                column: "IdCep",
                principalTable: "CEP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
