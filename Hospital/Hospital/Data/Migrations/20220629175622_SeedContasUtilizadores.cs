using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    public partial class SeedContasUtilizadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUtilizador",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "adf99a9d-e07d-4b70-a957-0e933e99f0ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "8da75472-0110-461f-a21f-3d91726a7c0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "u",
                column: "ConcurrencyStamp",
                value: "ddc6b0cd-2e93-447b-bd47-109956b3ad01");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataRegistro", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0c88c53b-f18e-494e-88ff-1e9c2360f310", 0, "58776b8f-28d4-4bd2-b8e4-85988decee6b", new DateTime(2022, 6, 29, 18, 56, 21, 537, DateTimeKind.Local).AddTicks(7872), "Henriques82648@email.com", true, true, null, "João Henriques", "HENRIQUES82648@EMAIL.COM", "JOÃO HENRIQUES", "AQAAAAEAACcQAAAAEMRGPimqvV4k1sMP4+ZVsKl9i6D6+kvgq1UZgUMrVEESfjiywAud4NpenOY4YFOSmw==", null, false, "953b5c96-5d6d-4e16-bc4a-11c1b6fa38fe", false, "João Henriques" },
                    { "10450067-5f19-44c7-8be1-388e8a6bdb30", 0, "1cadc5aa-187f-44d5-9fc3-c7a6e8b4d885", new DateTime(2022, 6, 29, 18, 56, 21, 571, DateTimeKind.Local).AddTicks(817), "Fernando60603@email.com", true, true, null, "João Fernando", "FERNANDO60603@EMAIL.COM", "FERNANDO60603@EMAIL.COM", "AQAAAAEAACcQAAAAEM83Zit1Ot8M/RfBmZ/2/qjx/Bm8IaMMW+1NORBUmbJZmbCDVjMESvNk0p8TfanFVA==", null, false, "a3e34d85-5672-4f1d-8702-2f2feac47e93", false, "Fernando60603@email.com" },
                    { "18d7e29d-408f-42d7-9a27-ecc5d034d157", 0, "692a698b-c360-4af0-928a-a5d9f702560e", new DateTime(2022, 6, 29, 18, 56, 21, 590, DateTimeKind.Local).AddTicks(1303), "belaHenriques@email.com", true, true, null, "Anabela Calçada Henriques Aveiro", "BELAHENRIQUES@EMAIL.COM", "BELAHENRIQUES@EMAIL.COM", "AQAAAAEAACcQAAAAEJE1kECpqkUGf/Kdy4YondaOvkkJSCmQwuhy77ocEtCneu3Nu7IZXHOk6VDnv8q+kg==", null, false, "fb1dc965-c621-434b-a929-e5ed8121c04c", false, "belaHenriques@email.com" },
                    { "29f5f36e-5f11-42a2-b0b8-de7741c7de16", 0, "51ced743-a76b-4209-a1b1-1399f4f780d6", new DateTime(2022, 6, 29, 18, 56, 21, 577, DateTimeKind.Local).AddTicks(3874), "teixeira@email.com", true, true, null, "Isabela Bentes Teixeira", "TEIXEIRA@EMAIL.COM", "TEIXEIRA@EMAIL.COM", "AQAAAAEAACcQAAAAEC//gSiqV9zMe4bHD/FoqfU7jVIeXUXZvym6R+/7COUGGchYLFmwdxsmDtZ0oE3FYw==", null, false, "8876967a-a60b-4d19-aeec-dbfb2f4d1b34", false, "teixeira@email.com" },
                    { "2db0257a-446d-4886-b46e-3f6246610080", 0, "d2f54cd4-f7f7-4db9-b833-9a3fc7857ca5", new DateTime(2022, 6, 29, 18, 56, 21, 544, DateTimeKind.Local).AddTicks(9970), "MarceloFerreira@email.com", true, true, null, "Marcelo Ferreira", "MARCELOFERREIRA@EMAIL.COM", "MARCELOFERREIRA@EMAIL.COM", "AQAAAAEAACcQAAAAELifoL5q9EV7PgJBZIp7/7Bp1Tg2odfvm4iWC6dXuya/2rpJX8xtNBMvsUfXETRPKQ==", null, false, "d01e507e-a9c9-46c7-9a40-f5b3f9494cda", false, "MarceloFerreira@email.com" },
                    { "388c89b7-046e-414a-8212-1cced6e1aea1", 0, "c6ec0f0f-62a1-43a8-a3aa-2cdea146e1c2", new DateTime(2022, 6, 29, 18, 56, 21, 522, DateTimeKind.Local).AddTicks(853), "cardoso@email.com", true, true, null, "Natália Cardoso", "CARDOSO@EMAIL.COM", "CARDOSO@EMAIL.COM", "AQAAAAEAACcQAAAAEA/HKFijVVZ5ItaqhNh6UkK6Gjb8oUgXzeULc/XBFmzsVZdEELfvRyq6hzB/N2tkKg==", null, false, "a43449ca-fe56-440a-9fbb-f02abaa1dd28", false, "cardoso@email.com" },
                    { "5db04ccb-3be8-452f-b381-47bd2277fdca", 0, "39b2b891-645d-4c2c-875d-b6b14c3c19a9", new DateTime(2022, 6, 29, 18, 56, 21, 596, DateTimeKind.Local).AddTicks(3313), "joaocelso@email.com", true, true, null, "João Celso Oliveira", "JOAOCELSO@EMAIL.COM", "JOAOCELSO@EMAIL.COM", "AQAAAAEAACcQAAAAEMUEFuqVWMFlMt/O/li/0Qsibrl+CR023yx7ahC8Cj/ka0/8gzVGQdTffUw09lXkwQ==", null, false, "1ae32a16-595a-4873-84d1-684906321141", false, "joaocelso@email.com" },
                    { "773922b7-74c3-4e4c-8097-fd7468ec8315", 0, "5fdfc97a-f0a6-485c-a7fc-4d8f4929a854", new DateTime(2022, 6, 29, 18, 56, 21, 552, DateTimeKind.Local).AddTicks(2057), "GabHenriques@email.com", true, true, null, "Gabriel Henriques", "GABHENRIQUES@EMAIL.COM", "GABHENRIQUES@EMAIL.COM", "AQAAAAEAACcQAAAAEIxx4aSIST5tCIRHc4J7qtcTsHsh8T+ZQV8XtH1163rTFEdTrZaWmfGrU/aSRnexVw==", null, false, "08743fa9-7ad7-4a9a-8f0a-7179fe903383", false, "GabHenriques@email.com" },
                    { "93b9ebd2-3f4d-4009-8d8b-3a3404f85628", 0, "cd5eecf7-169b-4fce-9d55-7ff636790a11", new DateTime(2022, 6, 29, 18, 56, 21, 515, DateTimeKind.Local).AddTicks(4522), "admin2@admin.com", true, true, null, "Admin2", "ADMIN2@ADMIN.COM", "ADMIN2@ADMIN.COM", "AQAAAAEAACcQAAAAEIy31RIwuVBoa97a6PDQRanEpEsW0l87Jtr+2TKOwSGL6vJQDtHQr2t77onlKHmKCw==", null, false, "bef47a86-ee13-4d30-8c38-c8b107d71d51", false, "admin2@admin.com" },
                    { "a370779b-8777-4d3b-a96c-7a94d217e355", 0, "6402b1d1-8834-406e-819f-840bfb5bd8c0", new DateTime(2022, 6, 29, 18, 56, 21, 509, DateTimeKind.Local).AddTicks(1588), "admin@admin.com", true, true, null, "Admin", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEIqmKOO70cRmcywibXS9F5LTVz/3hxubx9REirAvChGPlbjtmHedmDzJe6Z8fHYf2w==", null, false, "19c4de54-03da-47d2-af20-b6c380bf68d9", false, "admin@admin.com" },
                    { "a91d6e50-ec7a-442d-9278-4567dc61a0aa", 0, "b3e0c1f7-a428-4f8d-ac5c-05cbadaa4012", new DateTime(2022, 6, 29, 18, 56, 21, 583, DateTimeKind.Local).AddTicks(8504), "leonardo@email.com", true, true, null, "Leonardo Teves Dinis", "LEONARDO@EMAIL.COM", "LEONARDO@EMAIL.COM", "AQAAAAEAACcQAAAAELEooZy/yM7zZm1bWD4Mdrb8xzlCi+RYVTL+m8mMjQb6xKRljEgjMzpDguokXGRSEg==", null, false, "d40d376b-ce0e-4323-b577-35357e00acef", false, "leonardo@email.com" },
                    { "b092ad4f-06b8-427f-bc38-cab75e79fc7d", 0, "291650fb-2e10-4760-bf0c-ab9efbb8ec3a", new DateTime(2022, 6, 29, 18, 56, 21, 530, DateTimeKind.Local).AddTicks(7100), "Luizpaz59181@email.com", true, true, null, "Luiz Fernando da Paz", "LUIZPAZ59181@EMAIL.COM", "LUIZPAZ59181@EMAIL.COM", "AQAAAAEAACcQAAAAENegJFhSsDBIzSquRvXMw36HK979wcM3H9jDL5mixyr5NWkSXM5VdVXH7ny0NClBkw==", null, false, "92346495-29ac-4a4e-8fca-c3312d08d30b", false, "Luizpaz59181@email.com" },
                    { "db43e582-e359-421d-9192-1d3ad1a57737", 0, "c1ec890d-314e-4928-b248-d2a8a6342446", new DateTime(2022, 6, 29, 18, 56, 21, 602, DateTimeKind.Local).AddTicks(5477), "ineshenriques@email.com", true, true, null, "Maria Inês Silva Henriques", "INESHENRIQUES@EMAIL.COM", "INESHENRIQUES@EMAIL.COM", "AQAAAAEAACcQAAAAEAjxTsYuovmIEmdFdU5YvpGAmCOUuiFvvXjEKwhp6qnTy9Ax/6aJR4c17fzJLd6I8g==", null, false, "0ea6dd44-277a-4197-8ac8-cb0381fe713f", false, "ineshenriques@email.com" },
                    { "db9792d7-d293-49b5-be8d-03ccf60d0e33", 0, "f6fb53f8-cad5-472e-9a1e-acb92e9548c6", new DateTime(2022, 6, 29, 18, 56, 21, 558, DateTimeKind.Local).AddTicks(4548), "Carvalho69791@email.com", true, true, null, "David Carvalho", "CARVALHO69791@EMAIL.COM", "CARVALHO69791@EMAIL.COM", "AQAAAAEAACcQAAAAEAq6HyPpcARUG6IMf8WL56ExnkcicjIVgwN+P0TzFg4N0Tk7DQlu5637GAHJXPDkNw==", null, false, "b24f4f68-3c99-48d3-bf8f-d728e036cfd7", false, "Carvalho69791@email.com" },
                    { "e0585d26-607c-46d3-9eea-9c1c2708c7e1", 0, "c2c06911-e9bb-4074-ac6e-7356924a719f", new DateTime(2022, 6, 29, 18, 56, 21, 564, DateTimeKind.Local).AddTicks(8278), "Nogueira@email.com", true, true, null, "Carolina Nogueira", "NOGUEIRA@EMAIL.COM", "NOGUEIRA@EMAIL.COM", "AQAAAAEAACcQAAAAEGiTkn/1FAtxsRY9EAeriqAkGTyuz/TywgxCIEIkzh8WbYQtZe3feJPud7mPES09aw==", null, false, "6868c0ef-0310-4a05-98e0-934d06b3e654", false, "Nogueira@email.com" }
                });

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdUtilizador",
                value: "388c89b7-046e-414a-8212-1cced6e1aea1");

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdUtilizador",
                value: "b092ad4f-06b8-427f-bc38-cab75e79fc7d");

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdUtilizador",
                value: "0c88c53b-f18e-494e-88ff-1e9c2360f310");

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 4,
                column: "IdUtilizador",
                value: "2db0257a-446d-4886-b46e-3f6246610080");

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 5,
                column: "IdUtilizador",
                value: "773922b7-74c3-4e4c-8097-fd7468ec8315");

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 6,
                column: "IdUtilizador",
                value: "db9792d7-d293-49b5-be8d-03ccf60d0e33");

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 7,
                column: "IdUtilizador",
                value: "e0585d26-607c-46d3-9eea-9c1c2708c7e1");

            migrationBuilder.UpdateData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 8,
                column: "IdUtilizador",
                value: "10450067-5f19-44c7-8be1-388e8a6bdb30");

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdUtilizador",
                value: "29f5f36e-5f11-42a2-b0b8-de7741c7de16");

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdUtilizador",
                value: "a91d6e50-ec7a-442d-9278-4567dc61a0aa");

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdUtilizador",
                value: "18d7e29d-408f-42d7-9a27-ecc5d034d157");

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 4,
                column: "IdUtilizador",
                value: "5db04ccb-3be8-452f-b381-47bd2277fdca");

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 5,
                column: "IdUtilizador",
                value: "db43e582-e359-421d-9192-1d3ad1a57737");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "m", "0c88c53b-f18e-494e-88ff-1e9c2360f310" },
                    { "m", "10450067-5f19-44c7-8be1-388e8a6bdb30" },
                    { "u", "18d7e29d-408f-42d7-9a27-ecc5d034d157" },
                    { "u", "29f5f36e-5f11-42a2-b0b8-de7741c7de16" },
                    { "m", "2db0257a-446d-4886-b46e-3f6246610080" },
                    { "m", "388c89b7-046e-414a-8212-1cced6e1aea1" },
                    { "u", "5db04ccb-3be8-452f-b381-47bd2277fdca" },
                    { "m", "773922b7-74c3-4e4c-8097-fd7468ec8315" },
                    { "a", "93b9ebd2-3f4d-4009-8d8b-3a3404f85628" },
                    { "a", "a370779b-8777-4d3b-a96c-7a94d217e355" },
                    { "u", "a91d6e50-ec7a-442d-9278-4567dc61a0aa" },
                    { "m", "b092ad4f-06b8-427f-bc38-cab75e79fc7d" },
                    { "u", "db43e582-e359-421d-9192-1d3ad1a57737" },
                    { "m", "db9792d7-d293-49b5-be8d-03ccf60d0e33" },
                    { "m", "e0585d26-607c-46d3-9eea-9c1c2708c7e1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "m", "0c88c53b-f18e-494e-88ff-1e9c2360f310" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "m", "10450067-5f19-44c7-8be1-388e8a6bdb30" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "u", "18d7e29d-408f-42d7-9a27-ecc5d034d157" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "u", "29f5f36e-5f11-42a2-b0b8-de7741c7de16" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "m", "2db0257a-446d-4886-b46e-3f6246610080" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "m", "388c89b7-046e-414a-8212-1cced6e1aea1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "u", "5db04ccb-3be8-452f-b381-47bd2277fdca" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "m", "773922b7-74c3-4e4c-8097-fd7468ec8315" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a", "93b9ebd2-3f4d-4009-8d8b-3a3404f85628" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a", "a370779b-8777-4d3b-a96c-7a94d217e355" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "u", "a91d6e50-ec7a-442d-9278-4567dc61a0aa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "m", "b092ad4f-06b8-427f-bc38-cab75e79fc7d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "u", "db43e582-e359-421d-9192-1d3ad1a57737" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "m", "db9792d7-d293-49b5-be8d-03ccf60d0e33" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "m", "e0585d26-607c-46d3-9eea-9c1c2708c7e1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c88c53b-f18e-494e-88ff-1e9c2360f310");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10450067-5f19-44c7-8be1-388e8a6bdb30");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18d7e29d-408f-42d7-9a27-ecc5d034d157");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29f5f36e-5f11-42a2-b0b8-de7741c7de16");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2db0257a-446d-4886-b46e-3f6246610080");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "388c89b7-046e-414a-8212-1cced6e1aea1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5db04ccb-3be8-452f-b381-47bd2277fdca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "773922b7-74c3-4e4c-8097-fd7468ec8315");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93b9ebd2-3f4d-4009-8d8b-3a3404f85628");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a370779b-8777-4d3b-a96c-7a94d217e355");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a91d6e50-ec7a-442d-9278-4567dc61a0aa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b092ad4f-06b8-427f-bc38-cab75e79fc7d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db43e582-e359-421d-9192-1d3ad1a57737");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db9792d7-d293-49b5-be8d-03ccf60d0e33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0585d26-607c-46d3-9eea-9c1c2708c7e1");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Medicos");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "68edc053-8a34-46b5-9cbe-27ee339290e3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "bc6c3796-04c6-4e5c-b648-91f9d67f0756");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "u",
                column: "ConcurrencyStamp",
                value: "d8113b43-d7f8-4128-b89f-a4a855d11699");

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdUtilizador",
                value: null);

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdUtilizador",
                value: null);

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdUtilizador",
                value: null);

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 4,
                column: "IdUtilizador",
                value: null);

            migrationBuilder.UpdateData(
                table: "Utentes",
                keyColumn: "Id",
                keyValue: 5,
                column: "IdUtilizador",
                value: null);
        }
    }
}
