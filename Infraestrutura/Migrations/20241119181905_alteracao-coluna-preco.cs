using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class alteracaocolunapreco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "ItensVenda");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ItensVenda",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "ItensVenda",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ItensVenda");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "ItensVenda");

            migrationBuilder.AddColumn<double>(
                name: "PrecoUnitario",
                table: "ItensVenda",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
