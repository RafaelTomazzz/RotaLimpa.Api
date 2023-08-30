using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaLimpa.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    id_Empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_empresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome da empresa"),
                    cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.id_Empresa);
                });

            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Empresa = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    tipo_funcionario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.id_funcionario);
                    table.ForeignKey(
                        name: "FK_funcionario_Empresa_id_Empresa",
                        column: x => x.id_Empresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_id_Empresa",
                table: "funcionario",
                column: "id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_id_funcionario",
                table: "funcionario",
                column: "id_funcionario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
