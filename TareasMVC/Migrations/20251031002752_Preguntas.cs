using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasMVC.Migrations
{
    /// <inheritdoc />
    public partial class Preguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RespuestasJson",
                table: "Evaluaciones");

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionPregunta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Respuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<int>(type: "int", nullable: false),
                    TextoOtro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluacionId = table.Column<int>(type: "int", nullable: false),
                    PreguntaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuesta_Evaluaciones_EvaluacionId",
                        column: x => x.EvaluacionId,
                        principalTable: "Evaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respuesta_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_EvaluacionId",
                table: "Respuesta",
                column: "EvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_PreguntaId",
                table: "Respuesta",
                column: "PreguntaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respuesta");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.AddColumn<string>(
                name: "RespuestasJson",
                table: "Evaluaciones",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
