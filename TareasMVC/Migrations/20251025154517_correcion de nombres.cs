using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasMVC.Migrations
{
    /// <inheritdoc />
    public partial class correciondenombres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluaciones_Evaluador_EvaluadorId",
                table: "Evaluaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluaciones_Terminal_TerminalId",
                table: "Evaluaciones");

            migrationBuilder.DropColumn(
                name: "IdEvaluador",
                table: "Evaluaciones");

            migrationBuilder.DropColumn(
                name: "IdTerminal",
                table: "Evaluaciones");

            migrationBuilder.AlterColumn<int>(
                name: "TerminalId",
                table: "Evaluaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EvaluadorId",
                table: "Evaluaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluaciones_Evaluador_EvaluadorId",
                table: "Evaluaciones",
                column: "EvaluadorId",
                principalTable: "Evaluador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluaciones_Terminal_TerminalId",
                table: "Evaluaciones",
                column: "TerminalId",
                principalTable: "Terminal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluaciones_Evaluador_EvaluadorId",
                table: "Evaluaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluaciones_Terminal_TerminalId",
                table: "Evaluaciones");

            migrationBuilder.AlterColumn<int>(
                name: "TerminalId",
                table: "Evaluaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EvaluadorId",
                table: "Evaluaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdEvaluador",
                table: "Evaluaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTerminal",
                table: "Evaluaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluaciones_Evaluador_EvaluadorId",
                table: "Evaluaciones",
                column: "EvaluadorId",
                principalTable: "Evaluador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluaciones_Terminal_TerminalId",
                table: "Evaluaciones",
                column: "TerminalId",
                principalTable: "Terminal",
                principalColumn: "Id");
        }
    }
}
