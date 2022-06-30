using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    public partial class CorrigirSeedPagamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "7d7dbee2-6d76-4917-bdda-c60b567ed818");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "c7f68ae0-fe21-46c2-b3b3-a6c2cd208776");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "u",
                column: "ConcurrencyStamp",
                value: "d02bc915-5c42-40f1-b1f9-6b2314d58162");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c88c53b-f18e-494e-88ff-1e9c2360f310",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f3d5ebf-0800-4dd5-98ee-909fde2f2590", new DateTime(2022, 6, 30, 2, 45, 26, 779, DateTimeKind.Local).AddTicks(1488), "AQAAAAEAACcQAAAAEP04JMC4WlUz+wrJgadbdv8lvKHX3PLJRyPoGKO4XU459S7vmMqr3wkYk13KC0VsPQ==", "e2e8a113-072d-4212-875c-697127c09282" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10450067-5f19-44c7-8be1-388e8a6bdb30",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2517871-7ea0-4798-a4c1-4e7bdcfcd6b1", new DateTime(2022, 6, 30, 2, 45, 26, 826, DateTimeKind.Local).AddTicks(9584), "AQAAAAEAACcQAAAAELOLNQrMkAP2HMHLYDuU9IcoOYisT8dFFyR/7C5JxrthdJ97b9ylEyqZ0uF6aropiQ==", "8fdc9b67-3e18-4a58-9fcb-7151a5a11dcf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18d7e29d-408f-42d7-9a27-ecc5d034d157",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f1ae2c4-5211-4841-b82b-b3dac0dd1a70", new DateTime(2022, 6, 30, 2, 45, 26, 845, DateTimeKind.Local).AddTicks(5561), "AQAAAAEAACcQAAAAENR+NxnJzp4aqoHQsNwy0GQ7HA0V5Of9Z8YjPALUmhw7nAfJaW9f8BF6Vu9qibtlhw==", "6fc08e1d-c97a-451a-9714-46c4d96c1fbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29f5f36e-5f11-42a2-b0b8-de7741c7de16",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7369becd-67cc-4f21-ae5f-d070290dca3d", new DateTime(2022, 6, 30, 2, 45, 26, 833, DateTimeKind.Local).AddTicks(1435), "AQAAAAEAACcQAAAAEHSCgNsXCj2EhlSaSju0NCduk5bhjyRSezYDf02poNrTag1NxGbV/KUtjUFeeAr+dQ==", "45d1e180-7f89-4710-9133-3da848c379ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2db0257a-446d-4886-b46e-3f6246610080",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f7549f7-0643-4770-befa-9dd64dc12c66", new DateTime(2022, 6, 30, 2, 45, 26, 785, DateTimeKind.Local).AddTicks(5293), "AQAAAAEAACcQAAAAEMyn6Y/j8p4HTpugjIbF5XKjAHvDS6bZ15Vk5PZHpN1sF6CoyRufw3lWFDSoAcQ52A==", "c6eb88de-317e-4def-85be-40ae7b767b1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "388c89b7-046e-414a-8212-1cced6e1aea1",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9314f68-98fd-4aea-8761-8df204a5abb7", new DateTime(2022, 6, 30, 2, 45, 26, 762, DateTimeKind.Local).AddTicks(6259), "AQAAAAEAACcQAAAAEIz+mDs99QFsivpgZvktT7WjSnWeNL2TM/LXMGtGXnU+MKKcClP+jTeNrckVB/oiFw==", "35f078ba-ae01-40f5-a92a-42a9a84e24d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5db04ccb-3be8-452f-b381-47bd2277fdca",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29475fec-a232-4cc7-a852-b609f69a9236", new DateTime(2022, 6, 30, 2, 45, 26, 851, DateTimeKind.Local).AddTicks(8673), "AQAAAAEAACcQAAAAECV8BxcUm8fWwAK8RXXWu2vzNWzxDW58+RROj+ryPT1hHsQJAIzpf8WGj+7DbqRtNA==", "6eb2ca61-0b94-4138-beab-49e2cc3e6907" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "773922b7-74c3-4e4c-8097-fd7468ec8315",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfcda908-cf7a-457a-a339-1d26f8bf1bb7", new DateTime(2022, 6, 30, 2, 45, 26, 803, DateTimeKind.Local).AddTicks(7940), "AQAAAAEAACcQAAAAEC05yaK0rWmG66Fu+Ctv+hT1PnUw82nHy7n7LwJEEylxJ2UY787vKqojjk/yVEySvw==", "358bc881-e375-4d62-b044-f0c9e9cabd95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93b9ebd2-3f4d-4009-8d8b-3a3404f85628",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc2b3302-0865-41ce-bf0b-52233b79be4b", new DateTime(2022, 6, 30, 2, 45, 26, 753, DateTimeKind.Local).AddTicks(1220), "AQAAAAEAACcQAAAAEK/M/EauVL6IpjHe6ZfzxOKWVjIdbcgjm0cN/bjRFVrkyU1fCOGmrWmqGNP8vG3U+w==", "cd2ddfa3-ace8-4a85-ada5-d9b6ad27678d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a370779b-8777-4d3b-a96c-7a94d217e355",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d39f2cbd-c41e-4562-8d7d-e994ca7d6796", new DateTime(2022, 6, 30, 2, 45, 26, 746, DateTimeKind.Local).AddTicks(7716), "AQAAAAEAACcQAAAAENp1uesPUB4rAKGczpz+adUOnKa6gSRng18qu6NBOn3viV3kXMZRvjej2KeXmGs09A==", "816ca4b3-30e8-4781-9269-a8e0abe148c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a91d6e50-ec7a-442d-9278-4567dc61a0aa",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad39384c-231c-41ab-9c24-c4bb2119387e", new DateTime(2022, 6, 30, 2, 45, 26, 839, DateTimeKind.Local).AddTicks(3915), "AQAAAAEAACcQAAAAEMch2cm+yOSBLZr+7IR0NURDEt4z3+SYMntgpO846Ih84e0YM3VaD+qvIsEtAPk19A==", "39b6e71b-adc5-467b-97ca-fe826e55f8fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b092ad4f-06b8-427f-bc38-cab75e79fc7d",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e12e56f-3db5-4053-b8d1-bb332a0f8136", new DateTime(2022, 6, 30, 2, 45, 26, 772, DateTimeKind.Local).AddTicks(4133), "AQAAAAEAACcQAAAAEG1OP1T2fk1pzcSxYK7vwpXjJhYZPjSASfDCJoDnFUoOAP3ngF6hBRcJd64nwTwjNw==", "a1329bff-1a97-4924-931e-8c14db539c8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db43e582-e359-421d-9192-1d3ad1a57737",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b486048-3e0a-42ed-88c5-eeb2a238f865", new DateTime(2022, 6, 30, 2, 45, 26, 858, DateTimeKind.Local).AddTicks(1568), "AQAAAAEAACcQAAAAEH02JpNcQwgXaB7x0ak8z38mrWk4bD2nRMBJVw8xZdpPm5hrxKiGRA3E8JMqxGgYpw==", "1dea7450-f9e1-41a1-b2b4-928f223b4d41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db9792d7-d293-49b5-be8d-03ccf60d0e33",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65011658-d556-4e94-b7cf-5111c58c88a2", new DateTime(2022, 6, 30, 2, 45, 26, 813, DateTimeKind.Local).AddTicks(9545), "AQAAAAEAACcQAAAAEAXLwlBs6+K8H8hzQsTvxeDrCBDvPE2IfDQyGs21NFG7Zv4t3jre6TBYZYTVnw2CQA==", "adfc906a-d6c1-456b-96e8-401b08846798" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0585d26-607c-46d3-9eea-9c1c2708c7e1",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdbfec02-6d70-4225-a956-0a712f603e4d", new DateTime(2022, 6, 30, 2, 45, 26, 820, DateTimeKind.Local).AddTicks(7059), "AQAAAAEAACcQAAAAEEpFWvqR8NMLBIqdHj6+7jHlUsMUVUNwDBTla/Oh4Cd++uD7WhSMtwSjgSn82prxIw==", "3e945c7b-ee3d-43d1-8c27-0e95c7e4bb71" });

            migrationBuilder.UpdateData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConsultaFK",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConsultaFK",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c88c53b-f18e-494e-88ff-1e9c2360f310",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58776b8f-28d4-4bd2-b8e4-85988decee6b", new DateTime(2022, 6, 29, 18, 56, 21, 537, DateTimeKind.Local).AddTicks(7872), "AQAAAAEAACcQAAAAEMRGPimqvV4k1sMP4+ZVsKl9i6D6+kvgq1UZgUMrVEESfjiywAud4NpenOY4YFOSmw==", "953b5c96-5d6d-4e16-bc4a-11c1b6fa38fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10450067-5f19-44c7-8be1-388e8a6bdb30",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cadc5aa-187f-44d5-9fc3-c7a6e8b4d885", new DateTime(2022, 6, 29, 18, 56, 21, 571, DateTimeKind.Local).AddTicks(817), "AQAAAAEAACcQAAAAEM83Zit1Ot8M/RfBmZ/2/qjx/Bm8IaMMW+1NORBUmbJZmbCDVjMESvNk0p8TfanFVA==", "a3e34d85-5672-4f1d-8702-2f2feac47e93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18d7e29d-408f-42d7-9a27-ecc5d034d157",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "692a698b-c360-4af0-928a-a5d9f702560e", new DateTime(2022, 6, 29, 18, 56, 21, 590, DateTimeKind.Local).AddTicks(1303), "AQAAAAEAACcQAAAAEJE1kECpqkUGf/Kdy4YondaOvkkJSCmQwuhy77ocEtCneu3Nu7IZXHOk6VDnv8q+kg==", "fb1dc965-c621-434b-a929-e5ed8121c04c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29f5f36e-5f11-42a2-b0b8-de7741c7de16",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51ced743-a76b-4209-a1b1-1399f4f780d6", new DateTime(2022, 6, 29, 18, 56, 21, 577, DateTimeKind.Local).AddTicks(3874), "AQAAAAEAACcQAAAAEC//gSiqV9zMe4bHD/FoqfU7jVIeXUXZvym6R+/7COUGGchYLFmwdxsmDtZ0oE3FYw==", "8876967a-a60b-4d19-aeec-dbfb2f4d1b34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2db0257a-446d-4886-b46e-3f6246610080",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2f54cd4-f7f7-4db9-b833-9a3fc7857ca5", new DateTime(2022, 6, 29, 18, 56, 21, 544, DateTimeKind.Local).AddTicks(9970), "AQAAAAEAACcQAAAAELifoL5q9EV7PgJBZIp7/7Bp1Tg2odfvm4iWC6dXuya/2rpJX8xtNBMvsUfXETRPKQ==", "d01e507e-a9c9-46c7-9a40-f5b3f9494cda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "388c89b7-046e-414a-8212-1cced6e1aea1",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6ec0f0f-62a1-43a8-a3aa-2cdea146e1c2", new DateTime(2022, 6, 29, 18, 56, 21, 522, DateTimeKind.Local).AddTicks(853), "AQAAAAEAACcQAAAAEA/HKFijVVZ5ItaqhNh6UkK6Gjb8oUgXzeULc/XBFmzsVZdEELfvRyq6hzB/N2tkKg==", "a43449ca-fe56-440a-9fbb-f02abaa1dd28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5db04ccb-3be8-452f-b381-47bd2277fdca",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39b2b891-645d-4c2c-875d-b6b14c3c19a9", new DateTime(2022, 6, 29, 18, 56, 21, 596, DateTimeKind.Local).AddTicks(3313), "AQAAAAEAACcQAAAAEMUEFuqVWMFlMt/O/li/0Qsibrl+CR023yx7ahC8Cj/ka0/8gzVGQdTffUw09lXkwQ==", "1ae32a16-595a-4873-84d1-684906321141" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "773922b7-74c3-4e4c-8097-fd7468ec8315",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fdfc97a-f0a6-485c-a7fc-4d8f4929a854", new DateTime(2022, 6, 29, 18, 56, 21, 552, DateTimeKind.Local).AddTicks(2057), "AQAAAAEAACcQAAAAEIxx4aSIST5tCIRHc4J7qtcTsHsh8T+ZQV8XtH1163rTFEdTrZaWmfGrU/aSRnexVw==", "08743fa9-7ad7-4a9a-8f0a-7179fe903383" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93b9ebd2-3f4d-4009-8d8b-3a3404f85628",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd5eecf7-169b-4fce-9d55-7ff636790a11", new DateTime(2022, 6, 29, 18, 56, 21, 515, DateTimeKind.Local).AddTicks(4522), "AQAAAAEAACcQAAAAEIy31RIwuVBoa97a6PDQRanEpEsW0l87Jtr+2TKOwSGL6vJQDtHQr2t77onlKHmKCw==", "bef47a86-ee13-4d30-8c38-c8b107d71d51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a370779b-8777-4d3b-a96c-7a94d217e355",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6402b1d1-8834-406e-819f-840bfb5bd8c0", new DateTime(2022, 6, 29, 18, 56, 21, 509, DateTimeKind.Local).AddTicks(1588), "AQAAAAEAACcQAAAAEIqmKOO70cRmcywibXS9F5LTVz/3hxubx9REirAvChGPlbjtmHedmDzJe6Z8fHYf2w==", "19c4de54-03da-47d2-af20-b6c380bf68d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a91d6e50-ec7a-442d-9278-4567dc61a0aa",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3e0c1f7-a428-4f8d-ac5c-05cbadaa4012", new DateTime(2022, 6, 29, 18, 56, 21, 583, DateTimeKind.Local).AddTicks(8504), "AQAAAAEAACcQAAAAELEooZy/yM7zZm1bWD4Mdrb8xzlCi+RYVTL+m8mMjQb6xKRljEgjMzpDguokXGRSEg==", "d40d376b-ce0e-4323-b577-35357e00acef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b092ad4f-06b8-427f-bc38-cab75e79fc7d",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "291650fb-2e10-4760-bf0c-ab9efbb8ec3a", new DateTime(2022, 6, 29, 18, 56, 21, 530, DateTimeKind.Local).AddTicks(7100), "AQAAAAEAACcQAAAAENegJFhSsDBIzSquRvXMw36HK979wcM3H9jDL5mixyr5NWkSXM5VdVXH7ny0NClBkw==", "92346495-29ac-4a4e-8fca-c3312d08d30b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db43e582-e359-421d-9192-1d3ad1a57737",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1ec890d-314e-4928-b248-d2a8a6342446", new DateTime(2022, 6, 29, 18, 56, 21, 602, DateTimeKind.Local).AddTicks(5477), "AQAAAAEAACcQAAAAEAjxTsYuovmIEmdFdU5YvpGAmCOUuiFvvXjEKwhp6qnTy9Ax/6aJR4c17fzJLd6I8g==", "0ea6dd44-277a-4197-8ac8-cb0381fe713f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db9792d7-d293-49b5-be8d-03ccf60d0e33",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6fb53f8-cad5-472e-9a1e-acb92e9548c6", new DateTime(2022, 6, 29, 18, 56, 21, 558, DateTimeKind.Local).AddTicks(4548), "AQAAAAEAACcQAAAAEAq6HyPpcARUG6IMf8WL56ExnkcicjIVgwN+P0TzFg4N0Tk7DQlu5637GAHJXPDkNw==", "b24f4f68-3c99-48d3-bf8f-d728e036cfd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0585d26-607c-46d3-9eea-9c1c2708c7e1",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2c06911-e9bb-4074-ac6e-7356924a719f", new DateTime(2022, 6, 29, 18, 56, 21, 564, DateTimeKind.Local).AddTicks(8278), "AQAAAAEAACcQAAAAEGiTkn/1FAtxsRY9EAeriqAkGTyuz/TywgxCIEIkzh8WbYQtZe3feJPud7mPES09aw==", "6868c0ef-0310-4a05-98e0-934d06b3e654" });

            migrationBuilder.UpdateData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConsultaFK",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConsultaFK",
                value: 3);

            migrationBuilder.InsertData(
                table: "Pagamentos",
                columns: new[] { "Id", "ConsultaFK", "DataEfetuado", "Descricao", "Estado", "Metodo", "UtentesId", "Valor" },
                values: new object[] { 8, 3, null, "Taxa Moderadora", false, null, null, 12.5m });
        }
    }
}
