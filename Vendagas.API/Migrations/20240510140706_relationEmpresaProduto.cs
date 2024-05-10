using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vendagas.API.Migrations
{
    /// <inheritdoc />
    public partial class relationEmpresaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produto_EmpresaId",
                table: "Produto");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EmpresaId",
                table: "Produto",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produto_EmpresaId",
                table: "Produto");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EmpresaId",
                table: "Produto",
                column: "EmpresaId",
                unique: true);
        }
    }
}
