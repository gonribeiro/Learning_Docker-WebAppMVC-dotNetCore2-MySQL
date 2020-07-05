using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BokuNoHeroAcademia.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    NomeHeroi = table.Column<string>(maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DataMatricula = table.Column<DateTime>(nullable: true),
                    DataContratacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    ProfessorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoID);
                    table.ForeignKey(
                        name: "FK_Departamento_Pessoa_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Pessoa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoID = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 50, nullable: true),
                    Creditos = table.Column<int>(nullable: false),
                    DepartamentoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoID);
                    table.ForeignKey(
                        name: "FK_Curso_Departamento_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoAtribuido",
                columns: table => new
                {
                    ProfessorID = table.Column<int>(nullable: false),
                    CursoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoAtribuido", x => new { x.CursoID, x.ProfessorID });
                    table.ForeignKey(
                        name: "FK_CursoAtribuido_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoAtribuido_Pessoa_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Pessoa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscricao",
                columns: table => new
                {
                    InscricaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoId = table.Column<int>(nullable: false),
                    EstudanteId = table.Column<int>(nullable: false),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricao", x => x.InscricaoId);
                    table.ForeignKey(
                        name: "FK_Inscricao_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscricao_Pessoa_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "Pessoa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_DepartamentoID",
                table: "Curso",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_CursoAtribuido_ProfessorID",
                table: "CursoAtribuido",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_ProfessorID",
                table: "Departamento",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_CursoId",
                table: "Inscricao",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_EstudanteId",
                table: "Inscricao",
                column: "EstudanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoAtribuido");

            migrationBuilder.DropTable(
                name: "Inscricao");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
