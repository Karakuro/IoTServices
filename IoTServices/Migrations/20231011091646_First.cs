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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDevice = table.Column<int>(type: "int", nullable: false),
                    Temperatura = table.Column<float>(type: "real", nullable: false),
                    Umidita = table.Column<float>(type: "real", nullable: false),
                    Pressione = table.Column<float>(type: "real", nullable: false),
                    Altitudine = table.Column<float>(type: "real", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
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
