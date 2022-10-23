﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoAnimal = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.IdAnimal);
                });

            migrationBuilder.CreateTable(
                name: "Pecuarista",
                columns: table => new
                {
                    IdPecuarista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePecuarista = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecuarista", x => x.IdPecuarista);
                });

            migrationBuilder.CreateTable(
                name: "CompraGado",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPecuarista = table.Column<int>(type: "int", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraGado", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_CompraGado_Pecuarista_IdPecuarista",
                        column: x => x.IdPecuarista,
                        principalTable: "Pecuarista",
                        principalColumn: "IdPecuarista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompraGadoItem",
                columns: table => new
                {
                    IdCompraGadoItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompraGado = table.Column<int>(type: "int", nullable: false),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", maxLength: 999, nullable: false),
                    AnimalIdAnimal1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraGadoItem", x => x.IdCompraGadoItem);
                    table.ForeignKey(
                        name: "FK_CompraGadoItem_Animal_AnimalIdAnimal1",
                        column: x => x.AnimalIdAnimal1,
                        principalTable: "Animal",
                        principalColumn: "IdAnimal");
                    table.ForeignKey(
                        name: "FK_CompraGadoItem_Animal_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animal",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompraGadoItem_CompraGado_IdCompraGado",
                        column: x => x.IdCompraGado,
                        principalTable: "CompraGado",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraGado_IdPecuarista",
                table: "CompraGado",
                column: "IdPecuarista");

            migrationBuilder.CreateIndex(
                name: "IX_CompraGadoItem_AnimalIdAnimal1",
                table: "CompraGadoItem",
                column: "AnimalIdAnimal1");

            migrationBuilder.CreateIndex(
                name: "IX_CompraGadoItem_IdAnimal",
                table: "CompraGadoItem",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_CompraGadoItem_IdCompraGado",
                table: "CompraGadoItem",
                column: "IdCompraGado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraGadoItem");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "CompraGado");

            migrationBuilder.DropTable(
                name: "Pecuarista");
        }
    }
}
