using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Criandotabelaprodutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    categoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Table_Categorias_Table_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categorias_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Table_categoriaId",
                table: "Produtos_Table",
                column: "categoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos_Table");
        }
    }
}
