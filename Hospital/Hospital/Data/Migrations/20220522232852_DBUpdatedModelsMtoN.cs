using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    public partial class DBUpdatedModelsMtoN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidades_Medicos");

            migrationBuilder.AlterColumn<string>(
                name: "NumUtente",
                table: "Utentes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Pagamentos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UtentesId",
                table: "Pagamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumCedulaProf",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Consultas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_UtentesId",
                table: "Pagamentos",
                column: "UtentesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Utentes_UtentesId",
                table: "Pagamentos",
                column: "UtentesId",
                principalTable: "Utentes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Utentes_UtentesId",
                table: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_UtentesId",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "UtentesId",
                table: "Pagamentos");

            migrationBuilder.AlterColumn<int>(
                name: "NumUtente",
                table: "Utentes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Pagamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "NumCedulaProf",
                table: "Medicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Especialidades_Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspecialidadeFK = table.Column<int>(type: "int", nullable: false),
                    MedicoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Medicos_Especialidades_EspecialidadeFK",
                        column: x => x.EspecialidadeFK,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especialidades_Medicos_Medicos_MedicoFK",
                        column: x => x.MedicoFK,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_Medicos_EspecialidadeFK",
                table: "Especialidades_Medicos",
                column: "EspecialidadeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_Medicos_MedicoFK",
                table: "Especialidades_Medicos",
                column: "MedicoFK");
        }
    }
}
