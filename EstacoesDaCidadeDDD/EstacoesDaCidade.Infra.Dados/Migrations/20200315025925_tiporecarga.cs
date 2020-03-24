using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstacoesDaCidade.Infra.Dados.Migrations
{
    public partial class tiporecarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoRecarga",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRecarga", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoRecarga");
        }
    }
}
