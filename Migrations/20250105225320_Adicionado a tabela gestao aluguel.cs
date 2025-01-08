using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BikeRack.Migrations
{
    /// <inheritdoc />
    public partial class Adicionadoatabelagestaoaluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GestaoAluguel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bicicleta = table.Column<int>(type: "integer", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrancaFim = table.Column<int>(type: "integer", nullable: true),
                    HoraFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Cobranca = table.Column<decimal>(type: "numeric", nullable: true),
                    Ciclista = table.Column<int>(type: "integer", nullable: false),
                    TrancaInicio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestaoAluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GestaoAluguel_Ciclistas_Ciclista",
                        column: x => x.Ciclista,
                        principalTable: "Ciclistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GestaoAluguel_Ciclista",
                table: "GestaoAluguel",
                column: "Ciclista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GestaoAluguel");
        }
    }
}
