using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class TesteMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rua_Rota_RotaIdRota",
                table: "Rua");

            migrationBuilder.DropIndex(
                name: "IX_Rua_RotaIdRota",
                table: "Rua");

            migrationBuilder.DropColumn(
                name: "RotaIdRota",
                table: "Rua");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MtOcorrencia",
                table: "Ocorrencia",
                type: "datetime2",
                nullable: false,
                comment: "Data domento da ocorr�ncia",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Data domento da ocorrência");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RotaIdRota",
                table: "Rua",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MtOcorrencia",
                table: "Ocorrencia",
                type: "datetime2",
                nullable: false,
                comment: "Data domento da ocorrência",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Data domento da ocorr�ncia");

            migrationBuilder.CreateIndex(
                name: "IX_Rua_RotaIdRota",
                table: "Rua",
                column: "RotaIdRota");

            migrationBuilder.AddForeignKey(
                name: "FK_Rua_Rota_RotaIdRota",
                table: "Rua",
                column: "RotaIdRota",
                principalTable: "Rota",
                principalColumn: "Id");
        }
    }
}
