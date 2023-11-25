using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTituloArquivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "St_empresa",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: false,
                comment: "SITUAÇÃO DA EMPRESA",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "SITUAÇÃO DA EMPRESA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "St_empresa",
                table: "Empresa",
                type: "int",
                nullable: false,
                comment: "SITUAÇÃO DA EMPRESA",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "SITUAÇÃO DA EMPRESA");
        }
    }
}
