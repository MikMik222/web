using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ney_Nemovitost.web.Migrations
{
    public partial class fg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdresaVlastniku",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UliceACisloPop = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Obec = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Psc = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresaVlastniku", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DispoziceNemovitosti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dispozice = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispoziceNemovitosti", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dodatky",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idNemovitost = table.Column<int>(type: "int", nullable: false),
                    SrcToFile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dodatky", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnerNarocnostNemovitosti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnerNárocnost = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnerNarocnostNemovitosti", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KostrukceNemovitosti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Konstrukce = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KostrukceNemovitosti", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OptionNemovitost",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Volba = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VolbaJinyPad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionNemovitost", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Predvolby",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameCountry = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    predvolba = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predvolby", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypyDodatku",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypDodatku = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypyDodatku", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Najemnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    datumNarozeni = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idAdresa = table.Column<int>(type: "int", nullable: false),
                    vlastnikID = table.Column<int>(type: "int", nullable: false),
                    idPredvolby = table.Column<int>(type: "int", nullable: false),
                    jmeno = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prijmeni = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rodneCislo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefon = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Najemnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Najemnik_AdresaVlastniku_idAdresa",
                        column: x => x.idAdresa,
                        principalTable: "AdresaVlastniku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Najemnik_Predvolby_idPredvolby",
                        column: x => x.idPredvolby,
                        principalTable: "Predvolby",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    datumNarozeni = table.Column<DateOnly>(type: "date", nullable: false),
                    rodneCislo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idAdres = table.Column<int>(type: "int", nullable: false),
                    idPredvolby = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AdresaVlastniku_idAdres",
                        column: x => x.idAdres,
                        principalTable: "AdresaVlastniku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Predvolby_idPredvolby",
                        column: x => x.idPredvolby,
                        principalTable: "Predvolby",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Smlouva",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idNajemnik = table.Column<int>(type: "int", nullable: false),
                    idVlastnik = table.Column<int>(type: "int", nullable: false),
                    aktivni = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    idNemovitost = table.Column<int>(type: "int", nullable: false),
                    platnaOd = table.Column<DateOnly>(type: "date", nullable: false),
                    platnaDo = table.Column<DateOnly>(type: "date", nullable: false),
                    SrcToFile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smlouva", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Smlouva_Najemnik_idNajemnik",
                        column: x => x.idNajemnik,
                        principalTable: "Najemnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Nemovitos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idVlastnik = table.Column<int>(type: "int", nullable: false),
                    cenaEnergii = table.Column<double>(type: "double", nullable: false),
                    cenaSluzeb = table.Column<double>(type: "double", nullable: false),
                    cenaNajmu = table.Column<double>(type: "double", nullable: false),
                    idDizpozice = table.Column<int>(type: "int", nullable: false),
                    dostupnostOd = table.Column<DateOnly>(type: "date", nullable: false),
                    idEneNarocnosti = table.Column<int>(type: "int", nullable: false),
                    plocha = table.Column<double>(type: "double", nullable: false),
                    idAdresa = table.Column<int>(type: "int", nullable: false),
                    idTypBudovy = table.Column<int>(type: "int", nullable: false),
                    vybavenost = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nemovitos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nemovitos_AdresaVlastniku_idAdresa",
                        column: x => x.idAdresa,
                        principalTable: "AdresaVlastniku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nemovitos_DispoziceNemovitosti_idDizpozice",
                        column: x => x.idDizpozice,
                        principalTable: "DispoziceNemovitosti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nemovitos_EnerNarocnostNemovitosti_idEneNarocnosti",
                        column: x => x.idEneNarocnosti,
                        principalTable: "EnerNarocnostNemovitosti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nemovitos_OptionNemovitost_idTypBudovy",
                        column: x => x.idTypBudovy,
                        principalTable: "OptionNemovitost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nemovitos_Users_idVlastnik",
                        column: x => x.idVlastnik,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FotoNem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageSrc = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_Nemo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoNem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotoNem_Nemovitos_Id_Nemo",
                        column: x => x.Id_Nemo,
                        principalTable: "Nemovitos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Zavady",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idNemovitost = table.Column<int>(type: "int", nullable: false),
                    idmajitel = table.Column<int>(type: "int", nullable: false),
                    idNajemnik = table.Column<int>(type: "int", nullable: false),
                    popisZavady = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    popisOpravy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cenaOpravy = table.Column<double>(type: "double", nullable: false),
                    nazevOpravare = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    datumNahlaseni = table.Column<DateOnly>(type: "date", nullable: false),
                    datumOpravy = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zavady", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zavady_Najemnik_idNajemnik",
                        column: x => x.idNajemnik,
                        principalTable: "Najemnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zavady_Nemovitos_idNemovitost",
                        column: x => x.idNemovitost,
                        principalTable: "Nemovitos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zavady_Users_idmajitel",
                        column: x => x.idmajitel,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "DispoziceNemovitosti",
                columns: new[] { "ID", "Dispozice" },
                values: new object[,]
                {
                    { 1, "Garsoniéra" },
                    { 2, "1+kk" },
                    { 3, "1+1" },
                    { 4, "2+kk" },
                    { 5, "2+1" },
                    { 6, "3+kk" },
                    { 7, "3+1" },
                    { 8, "4+kk" },
                    { 9, "4+1" },
                    { 10, "5+kk" },
                    { 11, "5+1" },
                    { 12, "6+kk" },
                    { 13, "6+1" },
                    { 14, "7+kk" },
                    { 15, "7+1" },
                    { 16, "Ostatní" }
                });

            migrationBuilder.InsertData(
                table: "EnerNarocnostNemovitosti",
                columns: new[] { "ID", "EnerNárocnost" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" },
                    { 4, "D" },
                    { 5, "E" },
                    { 6, "F" },
                    { 7, "G" }
                });

            migrationBuilder.InsertData(
                table: "KostrukceNemovitosti",
                columns: new[] { "ID", "Konstrukce" },
                values: new object[,]
                {
                    { 1, "Dřevostavba" },
                    { 2, "Cihla" },
                    { 3, "Panel" },
                    { 4, "Nizkoenergetický" },
                    { 5, "Ostatní" }
                });

            migrationBuilder.InsertData(
                table: "OptionNemovitost",
                columns: new[] { "ID", "Volba", "VolbaJinyPad" },
                values: new object[,]
                {
                    { 1, "Byt", "Bytu" },
                    { 2, "Dům", "Domu" },
                    { 3, "Pozemek", "Pozemku" },
                    { 4, "Garáž", "Garáži" },
                    { 5, "Kancelář", "Kanceláře" },
                    { 6, "Nebytový prostor", "Nebytového prostoru" },
                    { 7, "Chaty a chalupy", "chaty a chalupy" }
                });

            migrationBuilder.InsertData(
                table: "Predvolby",
                columns: new[] { "ID", "NameCountry", "predvolba" },
                values: new object[,]
                {
                    { 1, "Afghanistan", 93 },
                    { 2, "Aland Islands", 358 },
                    { 3, "Albania", 355 },
                    { 4, "Algeria", 213 },
                    { 5, "American Samoa", 1 },
                    { 6, "Andorra", 376 },
                    { 7, "Angola", 244 },
                    { 8, "Anguilla", 1 },
                    { 9, "Antigua and Barbuda", 1 },
                    { 10, "Argentina", 54 },
                    { 11, "Armenia", 374 },
                    { 12, "Aruba", 297 },
                    { 13, "Australia", 61 },
                    { 14, "Austria", 43 },
                    { 15, "Azerbaijan", 994 },
                    { 16, "Bahamas", 1 },
                    { 17, "Bahrain", 973 },
                    { 18, "Bangladesh", 880 },
                    { 19, "Barbados", 1 },
                    { 20, "Belarus", 375 },
                    { 21, "Belgium", 32 },
                    { 22, "Belize", 501 },
                    { 23, "Benin", 229 },
                    { 24, "Bermuda", 1 },
                    { 25, "Bhutan", 975 },
                    { 26, "Bolivia", 591 },
                    { 27, "Bonaire, Sint Eustatius and Saba", 599 },
                    { 28, "Bosnia and Herzegovina", 387 },
                    { 29, "Botswana", 267 },
                    { 30, "Brazil", 55 },
                    { 31, "British Indian Ocean Territory", 246 },
                    { 32, "British Virgin Islands", 1 },
                    { 33, "Brunei", 673 },
                    { 34, "Bulgaria", 359 },
                    { 35, "Burkina Faso", 226 },
                    { 36, "Burundi", 257 },
                    { 37, "Cabo Verde", 238 },
                    { 38, "Cambodia", 855 },
                    { 39, "Cameroon", 237 },
                    { 40, "Canada", 1 },
                    { 41, "Caribbean", 0 },
                    { 42, "Cayman Islands", 1 },
                    { 43, "Central African Republic", 236 },
                    { 44, "Chad", 235 },
                    { 45, "Chile", 56 },
                    { 46, "China", 86 },
                    { 47, "Christmas Island", 61 },
                    { 48, "Cocos (Keeling) Islands", 61 },
                    { 49, "Colombia", 57 },
                    { 50, "Comoros", 269 },
                    { 51, "Congo", 242 },
                    { 52, "Congo (DRC)", 243 },
                    { 53, "Cook Islands", 682 },
                    { 54, "Costa Rica", 506 },
                    { 55, "CĂ´te dâ€™Ivoire", 225 },
                    { 56, "Croatia", 385 },
                    { 57, "Cuba", 53 },
                    { 58, "CuraĂ§ao", 599 },
                    { 59, "Cyprus", 357 },
                    { 60, "Czechia", 420 },
                    { 61, "Denmark", 45 },
                    { 62, "Djibouti", 253 },
                    { 63, "Dominica", 1 },
                    { 64, "Dominican Republic", 1 },
                    { 65, "Ecuador", 593 },
                    { 66, "Egypt", 20 },
                    { 67, "El Salvador", 503 },
                    { 68, "Equatorial Guinea", 240 },
                    { 69, "Eritrea", 291 },
                    { 70, "Estonia", 372 },
                    { 71, "Ethiopia", 251 },
                    { 72, "Europe", 0 },
                    { 73, "Falkland Islands", 500 },
                    { 74, "Faroe Islands", 298 },
                    { 75, "Fiji", 679 },
                    { 76, "Finland", 358 },
                    { 77, "France", 33 },
                    { 78, "French Guiana", 594 },
                    { 79, "French Polynesia", 689 },
                    { 80, "Gabon", 241 },
                    { 81, "Gambia", 220 },
                    { 82, "Georgia", 995 },
                    { 83, "Germany", 49 },
                    { 84, "Ghana", 233 },
                    { 85, "Gibraltar", 350 },
                    { 86, "Greece", 30 },
                    { 87, "Greenland", 299 },
                    { 88, "Grenada", 1 },
                    { 89, "Guadeloupe", 590 },
                    { 90, "Guam", 1 },
                    { 91, "Guatemala", 502 },
                    { 92, "Guernsey", 44 },
                    { 93, "Guinea", 224 },
                    { 94, "Guinea-Bissau", 245 },
                    { 95, "Guyana", 592 },
                    { 96, "Haiti", 509 },
                    { 97, "Honduras", 504 },
                    { 98, "Hong Kong SAR", 852 },
                    { 99, "Hungary", 36 },
                    { 100, "Iceland", 354 },
                    { 101, "India", 91 },
                    { 102, "Indonesia", 62 },
                    { 103, "Iran", 98 },
                    { 104, "Iraq", 964 },
                    { 105, "Ireland", 353 },
                    { 106, "Isle of Man", 44 },
                    { 107, "Israel", 972 },
                    { 108, "Italy", 39 },
                    { 109, "Jamaica", 1 },
                    { 110, "Japan", 81 },
                    { 111, "Jersey", 44 },
                    { 112, "Jordan", 962 },
                    { 113, "Kazakhstan", 7 },
                    { 114, "Kenya", 254 },
                    { 115, "Kiribati", 686 },
                    { 116, "Korea", 82 },
                    { 117, "Kosovo", 383 },
                    { 118, "Kuwait", 965 },
                    { 119, "Kyrgyzstan", 996 },
                    { 120, "Laos", 856 },
                    { 121, "Latin America", 0 },
                    { 122, "Latvia", 371 },
                    { 123, "Lebanon", 961 },
                    { 124, "Lesotho", 266 },
                    { 125, "Liberia", 231 },
                    { 126, "Libya", 218 },
                    { 127, "Liechtenstein", 423 },
                    { 128, "Lithuania", 370 },
                    { 129, "Luxembourg", 352 },
                    { 130, "Macao SAR", 853 },
                    { 131, "Macedonia, FYRO", 389 },
                    { 132, "Madagascar", 261 },
                    { 133, "Malawi", 265 },
                    { 134, "Malaysia", 60 },
                    { 135, "Maldives", 960 },
                    { 136, "Mali", 223 },
                    { 137, "Malta", 356 },
                    { 138, "Marshall Islands", 692 },
                    { 139, "Martinique", 596 },
                    { 140, "Mauritania", 222 },
                    { 141, "Mauritius", 230 },
                    { 142, "Mayotte", 262 },
                    { 143, "Mexico", 52 },
                    { 144, "Micronesia", 691 },
                    { 145, "Moldova", 373 },
                    { 146, "Monaco", 377 },
                    { 147, "Mongolia", 976 },
                    { 148, "Montenegro", 382 },
                    { 149, "Montserrat", 1 },
                    { 150, "Morocco", 212 },
                    { 151, "Mozambique", 258 },
                    { 152, "Myanmar", 95 },
                    { 153, "Namibia", 264 },
                    { 154, "Nauru", 674 },
                    { 155, "Nepal", 977 },
                    { 156, "Netherlands", 31 },
                    { 157, "New Caledonia", 687 },
                    { 158, "New Zealand", 64 },
                    { 159, "Nicaragua", 505 },
                    { 160, "Niger", 227 },
                    { 161, "Nigeria", 234 },
                    { 162, "Niue", 683 },
                    { 163, "Norfolk Island", 672 },
                    { 164, "North Korea", 850 },
                    { 165, "Northern Mariana Islands", 1 },
                    { 166, "Norway", 47 },
                    { 167, "Oman", 968 },
                    { 168, "Pakistan", 92 },
                    { 169, "Palau", 680 },
                    { 170, "Palestinian Authority", 970 },
                    { 171, "Panama", 507 },
                    { 172, "Papua New Guinea", 675 },
                    { 173, "Paraguay", 595 },
                    { 174, "Peru", 51 },
                    { 175, "Philippines", 63 },
                    { 176, "Pitcairn Islands", 0 },
                    { 177, "Poland", 48 },
                    { 178, "Portugal", 351 },
                    { 179, "Puerto Rico", 1 },
                    { 180, "Qatar", 974 },
                    { 181, "RĂ©union", 262 },
                    { 182, "Romania", 40 },
                    { 183, "Russia", 7 },
                    { 184, "Rwanda", 250 },
                    { 185, "Saint BarthĂ©lemy", 590 },
                    { 186, "Saint Kitts and Nevis", 1 },
                    { 187, "Saint Lucia", 1 },
                    { 188, "Saint Martin", 590 },
                    { 189, "Saint Pierre and Miquelon", 508 },
                    { 190, "Saint Vincent and the Grenadines", 1 },
                    { 191, "Samoa", 685 },
                    { 192, "San Marino", 378 },
                    { 193, "SĂŁo TomĂ© and PrĂ­ncipe", 239 },
                    { 194, "Saudi Arabia", 966 },
                    { 195, "Senegal", 221 },
                    { 196, "Serbia", 381 },
                    { 197, "Seychelles", 248 },
                    { 198, "Sierra Leone", 232 },
                    { 199, "Singapore", 65 },
                    { 200, "Sint Maarten", 1 },
                    { 201, "Slovakia", 421 },
                    { 202, "Slovenia", 386 },
                    { 203, "Solomon Islands", 677 },
                    { 204, "Somalia", 252 },
                    { 205, "South Africa", 27 },
                    { 206, "South Sudan", 211 },
                    { 207, "Spain", 34 },
                    { 208, "Sri Lanka", 94 },
                    { 209, "St Helena, Ascension, Tristan da Cunha", 290 },
                    { 210, "Sudan", 249 },
                    { 211, "Suriname", 597 },
                    { 212, "Svalbard and Jan Mayen", 47 },
                    { 213, "Swaziland", 268 },
                    { 214, "Sweden", 46 },
                    { 215, "Switzerland", 41 },
                    { 216, "Syria", 963 },
                    { 217, "Taiwan", 886 },
                    { 218, "Tajikistan", 992 },
                    { 219, "Tanzania", 255 },
                    { 220, "Thailand", 66 },
                    { 221, "Timor-Leste", 670 },
                    { 222, "Togo", 228 },
                    { 223, "Tokelau", 690 },
                    { 224, "Tonga", 676 },
                    { 225, "Trinidad and Tobago", 1 },
                    { 226, "Tunisia", 216 },
                    { 227, "Turkey", 90 },
                    { 228, "Turkmenistan", 993 },
                    { 229, "Turks and Caicos Islands", 1 },
                    { 230, "Tuvalu", 688 },
                    { 231, "U.S. Outlying Islands", 0 },
                    { 232, "U.S. Virgin Islands", 1 },
                    { 233, "Uganda", 256 },
                    { 234, "Ukraine", 380 },
                    { 235, "United Arab Emirates", 971 },
                    { 236, "United Kingdom", 44 },
                    { 237, "United States", 1 },
                    { 238, "Uruguay", 598 },
                    { 239, "Uzbekistan", 998 },
                    { 240, "Vanuatu", 678 },
                    { 241, "Vatican City", 39 },
                    { 242, "Venezuela", 58 },
                    { 243, "Vietnam", 84 },
                    { 244, "Wallis and Futuna", 681 },
                    { 245, "World", 0 },
                    { 246, "Yemen", 967 },
                    { 247, "Zambia", 260 },
                    { 248, "Zimbabwe", 263 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "9cf14c2c-19e7-40d6-b744-8917505c3106", "Vlastnik_Registrovany", "VLASTNIK_REGISTROVANY" });

            migrationBuilder.InsertData(
                table: "TypyDodatku",
                columns: new[] { "Id", "TypDodatku" },
                values: new object[,]
                {
                    { 1, "Článek 2 - změna maximálního počtu osob" },
                    { 2, "Článek 3 - doba nájmu" },
                    { 3, "Článek 4 - cena nájmu a služeb" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FotoNem_Id_Nemo",
                table: "FotoNem",
                column: "Id_Nemo");

            migrationBuilder.CreateIndex(
                name: "IX_Najemnik_idAdresa",
                table: "Najemnik",
                column: "idAdresa");

            migrationBuilder.CreateIndex(
                name: "IX_Najemnik_idPredvolby",
                table: "Najemnik",
                column: "idPredvolby");

            migrationBuilder.CreateIndex(
                name: "IX_Nemovitos_idAdresa",
                table: "Nemovitos",
                column: "idAdresa");

            migrationBuilder.CreateIndex(
                name: "IX_Nemovitos_idDizpozice",
                table: "Nemovitos",
                column: "idDizpozice");

            migrationBuilder.CreateIndex(
                name: "IX_Nemovitos_idEneNarocnosti",
                table: "Nemovitos",
                column: "idEneNarocnosti");

            migrationBuilder.CreateIndex(
                name: "IX_Nemovitos_idTypBudovy",
                table: "Nemovitos",
                column: "idTypBudovy");

            migrationBuilder.CreateIndex(
                name: "IX_Nemovitos_idVlastnik",
                table: "Nemovitos",
                column: "idVlastnik");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Smlouva_idNajemnik",
                table: "Smlouva",
                column: "idNajemnik");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_idAdres",
                table: "Users",
                column: "idAdres");

            migrationBuilder.CreateIndex(
                name: "IX_Users_idPredvolby",
                table: "Users",
                column: "idPredvolby");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zavady_idmajitel",
                table: "Zavady",
                column: "idmajitel");

            migrationBuilder.CreateIndex(
                name: "IX_Zavady_idNajemnik",
                table: "Zavady",
                column: "idNajemnik");

            migrationBuilder.CreateIndex(
                name: "IX_Zavady_idNemovitost",
                table: "Zavady",
                column: "idNemovitost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dodatky");

            migrationBuilder.DropTable(
                name: "FotoNem");

            migrationBuilder.DropTable(
                name: "KostrukceNemovitosti");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Smlouva");

            migrationBuilder.DropTable(
                name: "TypyDodatku");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Zavady");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Najemnik");

            migrationBuilder.DropTable(
                name: "Nemovitos");

            migrationBuilder.DropTable(
                name: "DispoziceNemovitosti");

            migrationBuilder.DropTable(
                name: "EnerNarocnostNemovitosti");

            migrationBuilder.DropTable(
                name: "OptionNemovitost");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AdresaVlastniku");

            migrationBuilder.DropTable(
                name: "Predvolby");
        }
    }
}
