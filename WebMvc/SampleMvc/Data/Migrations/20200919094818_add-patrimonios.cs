using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleMvc.Data.Migrations
{
    public partial class addpatrimonios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrimonio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPatrimonio = table.Column<int>(nullable: false),
                    NumeroSerie = table.Column<string>(nullable: true),
                    LocalId = table.Column<int>(nullable: false),
                    Coordenadas = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    Manutencao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimonio_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonio_LocalId",
                table: "Patrimonio",
                column: "LocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Local");
        }
    }
}
