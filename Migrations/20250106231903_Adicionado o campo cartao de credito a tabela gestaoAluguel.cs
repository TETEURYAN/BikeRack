using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRack.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoocampocartaodecreditoatabelagestaoAluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartaoDeCredito",
                table: "GestaoAluguel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GestaoAluguel_CartaoDeCredito",
                table: "GestaoAluguel",
                column: "CartaoDeCredito");

            migrationBuilder.AddForeignKey(
                name: "FK_GestaoAluguel_CartoesDeCredito_CartaoDeCredito",
                table: "GestaoAluguel",
                column: "CartaoDeCredito",
                principalTable: "CartoesDeCredito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GestaoAluguel_CartoesDeCredito_CartaoDeCredito",
                table: "GestaoAluguel");

            migrationBuilder.DropIndex(
                name: "IX_GestaoAluguel_CartaoDeCredito",
                table: "GestaoAluguel");

            migrationBuilder.DropColumn(
                name: "CartaoDeCredito",
                table: "GestaoAluguel");
        }
    }
}
