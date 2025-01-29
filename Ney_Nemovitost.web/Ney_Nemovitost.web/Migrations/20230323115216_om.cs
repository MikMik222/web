using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ney_Nemovitost.web.Migrations
{
    public partial class om : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "cena",
                table: "HistorieCen",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "MoznostiSluzeb",
                keyColumn: "ID",
                keyValue: 2,
                column: "NazevSluzby",
                value: "Cena vody");

            migrationBuilder.UpdateData(
                table: "MoznostiSluzeb",
                keyColumn: "ID",
                keyValue: 3,
                column: "NazevSluzby",
                value: "Cena plynu");

            migrationBuilder.InsertData(
                table: "MoznostiSluzeb",
                columns: new[] { "ID", "NazevSluzby" },
                values: new object[,]
                {
                    { 4, "Cena elektřiny" },
                    { 5, "Cena internetu" },
                    { 6, "Cena úklidu" },
                    { 7, "Cena odpadu" },
                    { 8, "Cena společné elektřiny" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MoznostiSluzeb",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MoznostiSluzeb",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MoznostiSluzeb",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MoznostiSluzeb",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MoznostiSluzeb",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "cena",
                table: "HistorieCen");

            migrationBuilder.UpdateData(
                table: "MoznostiSluzeb",
                keyColumn: "ID",
                keyValue: 2,
                column: "NazevSluzby",
                value: "Cena energie");

            migrationBuilder.UpdateData(
                table: "MoznostiSluzeb",
                keyColumn: "ID",
                keyValue: 3,
                column: "NazevSluzby",
                value: "Cena služeb");
        }
    }
}
