using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PobieranieDanychZBazy.Migrations
{
    public partial class Inicialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korespondencje",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DataWysylki = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korespondencje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pisma",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    Numer = table.Column<string>(nullable: true),
                    Priorytet = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pisma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorespondencjePisma",
                columns: table => new
                {
                    IdKorespondencja = table.Column<string>(nullable: false),
                    IdPismo = table.Column<string>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorespondencjePisma", x => new { x.IdKorespondencja, x.IdPismo });
                    table.ForeignKey(
                        name: "FK_KorespondencjePisma_Korespondencje_IdKorespondencja",
                        column: x => x.IdKorespondencja,
                        principalTable: "Korespondencje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorespondencjePisma_Pisma_IdPismo",
                        column: x => x.IdPismo,
                        principalTable: "Pisma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Korespondencje",
                columns: new[] { "Id", "DataWysylki" },
                values: new object[,]
                {
                    { "k1", new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "k2", new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Pisma",
                columns: new[] { "Id", "Nazwa", "Numer", "Priorytet" },
                values: new object[,]
                {
                    { "p1", "Pismo 1", "1/2020", false },
                    { "p2", "Pismo 2", "2/2020", false },
                    { "p3", "Pismo 3", "3/2020", true },
                    { "p4", "Pismo 4", "4/2020", true }
                });

            migrationBuilder.InsertData(
                table: "KorespondencjePisma",
                columns: new[] { "IdKorespondencja", "IdPismo", "Id" },
                values: new object[] { "k1", "p1", 1L });

            migrationBuilder.InsertData(
                table: "KorespondencjePisma",
                columns: new[] { "IdKorespondencja", "IdPismo", "Id" },
                values: new object[] { "k2", "p2", 3L });

            migrationBuilder.InsertData(
                table: "KorespondencjePisma",
                columns: new[] { "IdKorespondencja", "IdPismo", "Id" },
                values: new object[] { "k1", "p3", 2L });

            migrationBuilder.CreateIndex(
                name: "IX_KorespondencjePisma_IdPismo",
                table: "KorespondencjePisma",
                column: "IdPismo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorespondencjePisma");

            migrationBuilder.DropTable(
                name: "Korespondencje");

            migrationBuilder.DropTable(
                name: "Pisma");
        }
    }
}
