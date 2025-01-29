using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ney_Nemovitost.web.Migrations
{
    public partial class tfui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoznostiSluzeb",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NazevSluzby = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoznostiSluzeb", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistorieCen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idNemovitosti = table.Column<int>(type: "int", nullable: false),
                    idSluzby = table.Column<int>(type: "int", nullable: false),
                    cenaPlatnaOd = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorieCen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HistorieCen_MoznostiSluzeb_idSluzby",
                        column: x => x.idSluzby,
                        principalTable: "MoznostiSluzeb",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorieCen_Nemovitos_idNemovitosti",
                        column: x => x.idNemovitosti,
                        principalTable: "Nemovitos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "MoznostiSluzeb",
                columns: new[] { "ID", "NazevSluzby" },
                values: new object[] { 1, "Cena nájmu" });

            migrationBuilder.InsertData(
                table: "MoznostiSluzeb",
                columns: new[] { "ID", "NazevSluzby" },
                values: new object[] { 2, "Cena energie" });

            migrationBuilder.InsertData(
                table: "MoznostiSluzeb",
                columns: new[] { "ID", "NazevSluzby" },
                values: new object[] { 3, "Cena služeb" });

            migrationBuilder.CreateIndex(
                name: "IX_HistorieCen_idNemovitosti",
                table: "HistorieCen",
                column: "idNemovitosti");

            migrationBuilder.CreateIndex(
                name: "IX_HistorieCen_idSluzby",
                table: "HistorieCen",
                column: "idSluzby");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorieCen");

            migrationBuilder.DropTable(
                name: "MoznostiSluzeb");
        }
    }
}
