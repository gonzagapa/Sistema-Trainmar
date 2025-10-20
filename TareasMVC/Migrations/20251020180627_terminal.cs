using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TareasMVC.Migrations
{
    /// <inheritdoc />
    public partial class terminal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvaluador = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ApellidosEvaluador = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbreviaturaTerminal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NombreTerminal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEvaluador = table.Column<int>(type: "int", nullable: false),
                    EvaluadorId = table.Column<int>(type: "int", nullable: true),
                    IdTerminal = table.Column<int>(type: "int", nullable: false),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreEvaluado = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ApellidoEvaluado = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Evaluador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "Evaluador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Terminal_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fotografias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluacionId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotografias_Evaluaciones_EvaluacionId",
                        column: x => x.EvaluacionId,
                        principalTable: "Evaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Evaluador",
                columns: new[] { "Id", "ApellidosEvaluador", "NombreEvaluador" },
                values: new object[,]
                {
                    { 1, "Rodriguez Urreta", "Ruben Dario" },
                    { 2, "Alvarez Benitez", "Luis" },
                    { 3, "Gomez Hernandez", "Laura" },
                    { 4, "Izquierdo Jaramillo", "Paola" },
                    { 5, "Varas Violante", "Varick" }
                });

            migrationBuilder.InsertData(
                table: "Terminal",
                columns: new[] { "Id", "AbreviaturaTerminal", "NombreTerminal" },
                values: new object[,]
                {
                    { 1, "ICAVE", null },
                    { 2, "TIMSA", null },
                    { 3, "TILH", null },
                    { 4, "EIT", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_EvaluadorId",
                table: "Evaluaciones",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_TerminalId",
                table: "Evaluaciones",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografias_EvaluacionId",
                table: "Fotografias",
                column: "EvaluacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotografias");

            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Evaluador");

            migrationBuilder.DropTable(
                name: "Terminal");
        }
    }
}
