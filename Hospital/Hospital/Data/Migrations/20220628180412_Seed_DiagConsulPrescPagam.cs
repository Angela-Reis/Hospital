using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    public partial class Seed_DiagConsulPrescPagam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Consultas",
                columns: new[] { "Id", "Data", "DiagnosticoFK", "Estado", "MedicoFK", "Motivo", "UtenteFK" },
                values: new object[,]
                {
                    { 5, new DateTime(2022, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), null, "F", 1, "Check up Anual", 4 },
                    { 6, new DateTime(2022, 7, 1, 17, 15, 0, 0, DateTimeKind.Unspecified), null, "C", 1, "Check up Anual", 5 },
                    { 7, new DateTime(2022, 7, 29, 9, 30, 0, 0, DateTimeKind.Unspecified), null, "M", 6, "Dores nos Pulsos", 3 },
                    { 8, new DateTime(2022, 7, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), null, "P", 2, "Check up Anual", 2 }
                });

            migrationBuilder.InsertData(
                table: "Diagnosticos",
                columns: new[] { "Id", "Descricao", "Estado", "Titulo" },
                values: new object[,]
                {
                    { 1, "", "C", "Asma Brônquica" },
                    { 2, "", "T", "Aterosclerose" },
                    { 3, "", "F", "Gripe" }
                });

            migrationBuilder.InsertData(
                table: "EspecialidadesMedicos",
                columns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                values: new object[] { 8, 1 });

            migrationBuilder.InsertData(
                table: "Consultas",
                columns: new[] { "Id", "Data", "DiagnosticoFK", "Estado", "MedicoFK", "Motivo", "UtenteFK" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 19, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, "F", 1, "Dificuldade de Respiração", 1 },
                    { 2, new DateTime(2022, 6, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, "F", 2, "Recetemente tive dores no peito e senti-me Fadigado", 4 },
                    { 3, new DateTime(2022, 6, 26, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, "F", 1, "Check up após Consulta anterior relativa a Dificuldade de Respiração", 1 },
                    { 4, new DateTime(2022, 6, 26, 16, 45, 0, 0, DateTimeKind.Unspecified), 3, "F", 2, "Febre Alta", 5 }
                });

            migrationBuilder.InsertData(
                table: "Prescricoes",
                columns: new[] { "Id", "Data", "Descricao", "DiagnosticoFK", "Estado" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beclometasona quando for necessário, mínimo a cada 6 horas", 1, false },
                    { 2, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estatinas à noite", 2, true },
                    { 3, new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Formoterol duas vezes ao dia, de manhã e de noite", 1, true }
                });

            migrationBuilder.InsertData(
                table: "Pagamentos",
                columns: new[] { "Id", "ConsultaFK", "DataEfetuado", "Descricao", "Estado", "Metodo", "UtentesId", "Valor" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taxa Moderadora", true, "MB", null, 12.5m },
                    { 2, 1, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raio-X", true, "MB", null, 15m },
                    { 3, 2, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taxa Moderadora", true, "D", null, 12.5m },
                    { 4, 4, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exames Laboratoriais", true, "D", null, 35.62m },
                    { 5, 3, null, "Taxa Moderadora", false, null, null, 12.5m },
                    { 6, 3, null, "Taxa Moderadora", false, null, null, 12.5m },
                    { 7, 3, null, "Taxa Moderadora", false, null, null, 12.5m },
                    { 8, 3, null, "Taxa Moderadora", false, null, null, 12.5m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EspecialidadesMedicos",
                keyColumns: new[] { "ListaEspecialidadesId", "ListaMedicosId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diagnosticos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diagnosticos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diagnosticos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
