using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMotorista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Dc_Motorista",
                table: "Motorista",
                type: "datetime2",
                nullable: false,
                comment: "Data de cria��o do Motorista",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Data de criação do Motorista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Dc_Motorista",
                table: "Motorista",
                type: "datetime2",
                nullable: false,
                comment: "Data de criação do Motorista",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Data de cria��o do Motorista");
        }
    }
}
