using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBileteAvion.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinatie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aeroport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinatie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pasager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasager", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zbor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinatieID = table.Column<int>(type: "int", nullable: false),
                    DataOraPlecare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataOraSosire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zbor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zbor_Destinatie_DestinatieID",
                        column: x => x.DestinatieID,
                        principalTable: "Destinatie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZborID = table.Column<int>(type: "int", nullable: false),
                    PasagerID = table.Column<int>(type: "int", nullable: false),
                    Clasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bilet_Pasager_PasagerID",
                        column: x => x.PasagerID,
                        principalTable: "Pasager",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilet_Zbor_ZborID",
                        column: x => x.ZborID,
                        principalTable: "Zbor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_PasagerID",
                table: "Bilet",
                column: "PasagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_ZborID",
                table: "Bilet",
                column: "ZborID");

            migrationBuilder.CreateIndex(
                name: "IX_Zbor_DestinatieID",
                table: "Zbor",
                column: "DestinatieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilet");

            migrationBuilder.DropTable(
                name: "Pasager");

            migrationBuilder.DropTable(
                name: "Zbor");

            migrationBuilder.DropTable(
                name: "Destinatie");
        }
    }
}
