using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTServices.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IotData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDevice = table.Column<int>(type: "INTEGER", nullable: false),
                    Temperatura = table.Column<float>(type: "REAL", nullable: false),
                    Umidita = table.Column<float>(type: "REAL", nullable: false),
                    Pressione = table.Column<float>(type: "REAL", nullable: false),
                    Altitudine = table.Column<float>(type: "REAL", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IotData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IotData");
        }
    }
}
