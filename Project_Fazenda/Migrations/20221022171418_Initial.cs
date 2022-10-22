using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Project_Fazenda.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescricaoAnimal = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.IdAnimal);
                });

            migrationBuilder.CreateTable(
                name: "Pecuarista",
                columns: table => new
                {
                    IdPecuarista = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomePecuarista = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecuarista", x => x.IdPecuarista);
                });

            migrationBuilder.CreateTable(
                name: "CompraGado",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "integer", nullable: false),
                    IdPecuarista = table.Column<int>(type: "integer", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraGado", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_CompraGado_Pecuarista_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Pecuarista",
                        principalColumn: "IdPecuarista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompraGadoEm",
                columns: table => new
                {
                    IdCompraEm = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCompraGado = table.Column<int>(type: "integer", nullable: false),
                    CompraGadoIdCompra = table.Column<int>(type: "integer", nullable: true),
                    IdAnimal = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", maxLength: 999, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraGadoEm", x => x.IdCompraEm);
                    table.ForeignKey(
                        name: "FK_CompraGadoEm_Animais_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animais",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraGadoEm_CompraGado_CompraGadoIdCompra",
                        column: x => x.CompraGadoIdCompra,
                        principalTable: "CompraGado",
                        principalColumn: "IdCompra");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraGadoEm_CompraGadoIdCompra",
                table: "CompraGadoEm",
                column: "CompraGadoIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_CompraGadoEm_IdAnimal",
                table: "CompraGadoEm",
                column: "IdAnimal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraGadoEm");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "CompraGado");

            migrationBuilder.DropTable(
                name: "Pecuarista");
        }
    }
}
