using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    public partial class seed_EspecialidadesMedicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Clínica Geral" },
                    { 2, "Cardiologia" },
                    { 3, "Dermatologia" },
                    { 4, "Neurologia" },
                    { 5, "Psiquiatria" },
                    { 6, "Cirurgia Geral" },
                    { 7, "Pediatria" },
                    { 8, "Pneumologia" }
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "DataNascimento", "Email", "Foto", "Nome", "NumCedulaProf", "NumTelefone" },
                values: new object[,]
                {
                    { 1, new DateTime(1975, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "cardoso@email.com", "45485.png", "Natália Cardoso", "45485", "931111111" },
                    { 2, new DateTime(1971, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luizpaz59181@email.com", "semFoto.png", "Luiz Fernando da Paz", "59181", "912222222" },
                    { 3, new DateTime(1978, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Henriques82648@email.com", "72648.png", "João Henriques", "72648", "963333333" },
                    { 4, new DateTime(1969, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "MarceloFerreira@email.com", "semFoto.png", "Marcelo Ferreira", "40603", "964444444" },
                    { 5, new DateTime(1975, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "GabHenriques@email.com", "semFoto.png", "Gabriel Henriques", "45485", "935555555" },
                    { 6, new DateTime(1974, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carvalho69791@email.com", "semFoto.png", "David Carvalho", "69791", "966666666" },
                    { 7, new DateTime(1981, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nogueira@email.com", "semFoto.png", "Carolina Nogueira", "82666", "937777777" },
                    { 8, new DateTime(1976, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fernando60603@email.com", "60603.png", "João Fernando", "60603", "918888888" }
                });

            migrationBuilder.InsertData(
                table: "EspecialidadesMedicos",
                columns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 6 },
                    { 1, 7 },
                    { 2, 2 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 4 },
                    { 5, 1 },
                    { 7, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
