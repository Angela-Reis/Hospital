using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    public partial class consultaDiagnosticoFKNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Diagnosticos_DiagnosticoFK",
                table: "Consultas");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosticoFK",
                table: "Consultas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Diagnosticos_DiagnosticoFK",
                table: "Consultas",
                column: "DiagnosticoFK",
                principalTable: "Diagnosticos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Diagnosticos_DiagnosticoFK",
                table: "Consultas");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosticoFK",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Diagnosticos_DiagnosticoFK",
                table: "Consultas",
                column: "DiagnosticoFK",
                principalTable: "Diagnosticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
