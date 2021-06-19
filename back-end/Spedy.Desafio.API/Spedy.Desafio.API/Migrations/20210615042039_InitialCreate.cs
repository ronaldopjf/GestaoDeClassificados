using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spedy.Desafio.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CLASSIFICADO",
                columns: table => new
                {
                    ID_CLASSIFICADO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_TITULO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DS_DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DT_DATA = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    FL_ATIVO = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLASSIFICADO", x => x.ID_CLASSIFICADO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLASSIFICADO");
        }
    }
}
