using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCep",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_IdCep",
                table: "Ocorrencia",
                column: "IdCep");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_CEP_IdCep",
                table: "Ocorrencia",
                column: "IdCep",
                principalTable: "CEP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_CEP_IdCep",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_IdCep",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "IdCep",
                table: "Ocorrencia");
        }
    }
}
