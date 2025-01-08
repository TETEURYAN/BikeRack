using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRack.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacaodoscamposdatabelaciclista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Ciclistas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Ciclistas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Cvv",
                table: "CartoesDeCredito",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Ciclistas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ciclistas");

            migrationBuilder.AlterColumn<int>(
                name: "Cvv",
                table: "CartoesDeCredito",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
