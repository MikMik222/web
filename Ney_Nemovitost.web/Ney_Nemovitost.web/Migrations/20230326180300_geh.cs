using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ney_Nemovitost.web.Migrations
{
    public partial class geh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorieCen_Nemovitos_idNemovitosti",
                table: "HistorieCen");

            migrationBuilder.DropTable(
                name: "Dodatky");

            migrationBuilder.DropIndex(
                name: "IX_HistorieCen_idNemovitosti",
                table: "HistorieCen");

            migrationBuilder.AlterColumn<string>(
                name: "popisOpravy",
                table: "Zavady",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "nazevOpravare",
                table: "Zavady",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dodatek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idDodatku = table.Column<int>(type: "int", nullable: false),
                    srcToPdf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idSmlouva = table.Column<int>(type: "int", nullable: false),
                    idNemovitost = table.Column<int>(type: "int", nullable: false),
                    datumPlatnosti = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dodatek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dodatek_TypyDodatku_idDodatku",
                        column: x => x.idDodatku,
                        principalTable: "TypyDodatku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Dodatek_idDodatku",
                table: "Dodatek",
                column: "idDodatku");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dodatek");

            migrationBuilder.UpdateData(
                table: "Zavady",
                keyColumn: "popisOpravy",
                keyValue: null,
                column: "popisOpravy",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "popisOpravy",
                table: "Zavady",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Zavady",
                keyColumn: "nazevOpravare",
                keyValue: null,
                column: "nazevOpravare",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "nazevOpravare",
                table: "Zavady",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dodatky",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SrcToFile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idNemovitost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dodatky", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HistorieCen_idNemovitosti",
                table: "HistorieCen",
                column: "idNemovitosti");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorieCen_Nemovitos_idNemovitosti",
                table: "HistorieCen",
                column: "idNemovitosti",
                principalTable: "Nemovitos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
