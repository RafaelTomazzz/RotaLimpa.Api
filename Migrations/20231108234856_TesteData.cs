using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class TesteData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kilometragem_Frota_FrotaId_Veiculo",
                table: "Kilometragem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Da_Setor",
                table: "Setor",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "FrotaId_Veiculo",
                table: "Kilometragem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Kilometragem_Frota_FrotaId_Veiculo",
                table: "Kilometragem",
                column: "FrotaId_Veiculo",
                principalTable: "Frota",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kilometragem_Frota_FrotaId_Veiculo",
                table: "Kilometragem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Da_Setor",
                table: "Setor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FrotaId_Veiculo",
                table: "Kilometragem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kilometragem_Frota_FrotaId_Veiculo",
                table: "Kilometragem",
                column: "FrotaId_Veiculo",
                principalTable: "Frota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
