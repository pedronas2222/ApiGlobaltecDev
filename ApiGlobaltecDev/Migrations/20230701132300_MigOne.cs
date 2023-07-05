using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGlobaltecDev.Migrations
{
    /// <inheritdoc />
    public partial class MigOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasAPagar",
                columns: table => new
                {
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoFornecedor = table.Column<long>(type: "bigint", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataProrrogacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Acressimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
            constraints: table =>
            {
                table.PrimaryKey("PK_ContasAPagar", x => x.Numero);
                table.ForeignKey(
                    name: "FK_ContasAPagar_ContasApagar_CodigoFornecedor",
                    column: x => x.CodigoFornecedor,
                    principalTable: "ContasApagar",
                    principalColumn: "Numero",
                    onDelete: ReferentialAction.NoAction);

                table.PrimaryKey("PK_ContasAPagar", x => x.Numero);
            });






            migrationBuilder.CreateTable(
                name: "ContasPagas",
                columns: table => new
                {
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoFornecedor = table.Column<long>(type: "bigint", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataProrrogacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Acressimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPagas", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_ContasPagas_ContasPagas_CodigoFornecedor",
                        column: x => x.CodigoFornecedor,
                        principalTable: "ContasPagas",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.NoAction);

                    table.PrimaryKey("PK_ContasPagas", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    cpfCnpj = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Codigo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasAPagar");

            migrationBuilder.DropTable(
                name: "ContasPagas");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
