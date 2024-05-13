using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstRun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeArquivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Arquivo__3214EC07AF62A4B5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sistema",
                columns: table => new
                {
                    SistemaId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Chave = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sistema__4C36BB8622AE2DCF", x => x.SistemaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "Sistema");
        }
    }
}
