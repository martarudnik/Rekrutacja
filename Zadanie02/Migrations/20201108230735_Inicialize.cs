using Microsoft.EntityFrameworkCore.Migrations;

namespace Zadanie02.Migrations
{
    public partial class Inicialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pisma",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    Rocznik = table.Column<int>(nullable: false),
                    Priorytet = table.Column<bool>(nullable: false),
                    CzySkasowany = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pisma", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pisma",
                columns: new[] { "Id", "CzySkasowany", "Nazwa", "Priorytet", "Rocznik" },
                values: new object[,]
                {
                    { "p1", false, "Pismo 1", false, 2019 },
                    { "p2", false, "Pismo 2", true, 2019 },
                    { "p3", true, "Pismo 3", true, 2019 },
                    { "p4", true, "Pismo 4", false, 2019 },
                    { "p5", false, "Pismo 5", false, 2020 },
                    { "p6", false, "Pismo 6", true, 2020 },
                    { "p7", true, "Pismo 7", true, 2020 },
                    { "p8", true, "Pismo 8", false, 2020 },
                    { "p9", false, "Pismo 9", false, 2020 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pisma");
        }
    }
}
