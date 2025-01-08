using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRack.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "serial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Funcionarios",
                type: "serial",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
