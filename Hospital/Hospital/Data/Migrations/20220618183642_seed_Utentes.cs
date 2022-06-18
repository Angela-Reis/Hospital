using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    public partial class seed_Utentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Utentes",
                columns: new[] { "Id", "DataNascimento", "Email", "Foto", "NIF", "Nome", "NumTelemovel", "NumUtente", "Sexo" },
                values: new object[,]
                {
                    { 1, new DateTime(1979, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "teixeira@email.com", "semFoto.png", "270131221", "Isabela Bentes Teixeira", "911111111", "111111111", "F" },
                    { 2, new DateTime(1988, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "leonardo@email.com", "222222222.png", "244340862", "Leonardo Teves Dinis", "932222222", "222222222", "M" },
                    { 3, new DateTime(1968, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "belaHenriques@email.com", "333333333.png", "290254388", "Anabela Calçada Henriques Aveiro", "933333333", "333333333", "F" },
                    { 4, new DateTime(1963, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "joaocelso@email.com", "semFoto.png", "270131221", "João Celso Oliveira", "914444444", "444444444", "M" },
                    { 5, new DateTime(1990, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ineshenriques@email.com", "555555555.png", "270131221", "Maria Inês Silva Henriques", "915555555", "555555555", "F" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
