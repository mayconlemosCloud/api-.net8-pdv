using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class alteracaocolunapreco1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ItensVenda");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "ItensVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
