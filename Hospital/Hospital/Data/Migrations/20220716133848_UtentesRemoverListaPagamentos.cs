using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    public partial class UtentesRemoverListaPagamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Utentes_UtentesId",
                table: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_UtentesId",
                table: "Pagamentos");

            migrationBuilder.DeleteData(
                table: "Pagamentos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "UtentesId",
                table: "Pagamentos");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "f3bb8cca-9693-4838-9248-e496b8f29d30");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "e4d347ad-d73b-487d-a7f5-0bb3eb545ee8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "u",
                column: "ConcurrencyStamp",
                value: "7c4603b6-6040-4a26-b6a6-3a121352f1ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c88c53b-f18e-494e-88ff-1e9c2360f310",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e000812b-e146-47b3-8fd5-da53b6966381", new DateTime(2022, 7, 16, 14, 38, 48, 212, DateTimeKind.Local).AddTicks(8228), "AQAAAAEAACcQAAAAEKGW+Q84z2ediCqc+OcXuzxhZbNaK/jLzrOxJ1qVBElAAB5CbPnt7sRnJCinH7grCg==", "fbe40b83-2714-4ace-a93b-575cb5b87a9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10450067-5f19-44c7-8be1-388e8a6bdb30",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2913e9e5-286a-4b1e-b247-45b256c0a4bb", new DateTime(2022, 7, 16, 14, 38, 48, 243, DateTimeKind.Local).AddTicks(2158), "AQAAAAEAACcQAAAAEEBQB5RttO44HwMuIxkAUBUZL1W9/TBi0Kwgkf7Nn2G5KGr/lWzseVV1Gmy/ffU1RQ==", "532a3f1b-a4a2-443f-abc7-325bcab79c88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18d7e29d-408f-42d7-9a27-ecc5d034d157",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c576d2d-91ad-4e4a-ae57-d06d96d8c75c", new DateTime(2022, 7, 16, 14, 38, 48, 261, DateTimeKind.Local).AddTicks(4506), "AQAAAAEAACcQAAAAEHcjHOgqeLLPay90wFMrPl/mRN09hmiGnAjg8I+0BkKu1xFfRbrmd3AaS6VZw4YpRA==", "82bd8315-a15a-4178-8f5b-0c0cfab12ddf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29f5f36e-5f11-42a2-b0b8-de7741c7de16",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "628356ca-07c3-4ba0-820c-b334d87a9f82", new DateTime(2022, 7, 16, 14, 38, 48, 249, DateTimeKind.Local).AddTicks(2513), "AQAAAAEAACcQAAAAEKOuDHdDS0pu2WC3DkmFoaJ2mnoopoYPDbQuS7SO45DeWvWioynWArpmQsE3eCHVmw==", "226e0f0b-c9d8-4d5e-870f-bb6451c0ac36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2db0257a-446d-4886-b46e-3f6246610080",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4cdd7bf-2d6d-4715-9130-9ef023734ea2", new DateTime(2022, 7, 16, 14, 38, 48, 218, DateTimeKind.Local).AddTicks(8809), "AQAAAAEAACcQAAAAEDjeswkM3FjvnJmiDbsm06TID5AApyaOAFILQAX+vtcwl1veDPkjDsgVCpu866NYHQ==", "545635e0-9fb8-4a4e-b963-dcc6cc5ce6ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "388c89b7-046e-414a-8212-1cced6e1aea1",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c956447-cbfb-4d28-8004-f04444b3e6f2", new DateTime(2022, 7, 16, 14, 38, 48, 200, DateTimeKind.Local).AddTicks(5848), "AQAAAAEAACcQAAAAEL1ZLX+MTQujv33Nc8soXBz0CymbHtToUy+svjXr1F0zPjUuRyZ9LlNvkIfudTGUKA==", "79cd8603-6425-49af-857d-a18fb81f14e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5db04ccb-3be8-452f-b381-47bd2277fdca",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36ef9803-0074-4a90-94a5-f8ee3a8ce4a6", new DateTime(2022, 7, 16, 14, 38, 48, 267, DateTimeKind.Local).AddTicks(4671), "AQAAAAEAACcQAAAAEPH+QvtABRMyHXcQjKy8n8G/DpFtU4hYfkJON9yT0+c6v+LyAXw4nFobFq6izXxhmw==", "e5a8e581-583d-4f9e-b5d4-0927d845d09d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "773922b7-74c3-4e4c-8097-fd7468ec8315",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e0326ec-47bc-4e52-9e32-c3dde44f0e42", new DateTime(2022, 7, 16, 14, 38, 48, 225, DateTimeKind.Local).AddTicks(399), "AQAAAAEAACcQAAAAEKg1GEqTZm/IEvl/3gDEHRPHiVM8k8jK4jZ1HVdD+Z5qVpe0oVi0l8q3m754tgx0aw==", "ed0c2e0b-6725-47aa-8dfe-2d39be372b3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93b9ebd2-3f4d-4009-8d8b-3a3404f85628",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28ed5877-7581-4220-a22f-e83c68653090", new DateTime(2022, 7, 16, 14, 38, 48, 194, DateTimeKind.Local).AddTicks(3363), "AQAAAAEAACcQAAAAEOo/aNt6JMO6/32RRKK4ZNchczMZlxGEWbc3+V0OTa+qXD0OBys9kvUnATXMvfZTDQ==", "f6fa3ac7-a67c-461e-9c37-e739efe418e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a370779b-8777-4d3b-a96c-7a94d217e355",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a2ab385-9965-4182-8d20-878ee3b04f80", new DateTime(2022, 7, 16, 14, 38, 48, 188, DateTimeKind.Local).AddTicks(904), "AQAAAAEAACcQAAAAEA6rhrlQYR9U6opih6MFIGoJ1SOsyNRecWs6ylmB4R051VusWK2UAhr+I6mOzW6T4g==", "25acb752-7e79-4098-996d-b4dcac199892" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a91d6e50-ec7a-442d-9278-4567dc61a0aa",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d11b22f-d01a-40fe-a500-a664bb6affa9", new DateTime(2022, 7, 16, 14, 38, 48, 255, DateTimeKind.Local).AddTicks(3221), "AQAAAAEAACcQAAAAEN0g0S1ZJQLQ0Opa6ZMlKJ0uvFLMwS1J4YQxuDBJWYQDCT58eGk7qecijU+4IRme0A==", "b3581d65-fc0b-43c3-b727-318c0cdbb01b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b092ad4f-06b8-427f-bc38-cab75e79fc7d",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a061b29f-90ef-4011-8279-f6988ef3037e", new DateTime(2022, 7, 16, 14, 38, 48, 206, DateTimeKind.Local).AddTicks(6880), "AQAAAAEAACcQAAAAEFoLS1GcBPUt7H+Fajg7URC4P5EQUdRzoVOo1op1erBay27fvrIy1vct/xnJoNTD6g==", "fa3815c2-d05a-49ba-9d25-46d5cede085f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db43e582-e359-421d-9192-1d3ad1a57737",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86366f36-73a9-41d3-ac88-9cd26e681d9d", new DateTime(2022, 7, 16, 14, 38, 48, 273, DateTimeKind.Local).AddTicks(5591), "AQAAAAEAACcQAAAAELcvr1+krrk+PHfwpPNaguTslYhjLFazTT10lIIjYcXqCT/1BXS/lNXa7wAAE5h/Rw==", "43367474-9e8a-481c-b189-2e3a87d79924" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db9792d7-d293-49b5-be8d-03ccf60d0e33",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7eab589-b07c-4f66-8771-1f2a9be22965", new DateTime(2022, 7, 16, 14, 38, 48, 231, DateTimeKind.Local).AddTicks(1136), "AQAAAAEAACcQAAAAECFQxPwlpotiNrF/SI+UjZCpgLu9zyzA1MRuEuSAVi9bqbpmkvGD8skdlNM/vMgRfg==", "4b7f2460-c550-480b-a8d6-5f8e6855f304" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0585d26-607c-46d3-9eea-9c1c2708c7e1",
                columns: new[] { "ConcurrencyStamp", "DataRegistro", "PasswordHash", "SecurityStamp" },
                values: new object[] { "971267bb-4a92-431d-a107-95a5d19c102d", new DateTime(2022, 7, 16, 14, 38, 48, 237, DateTimeKind.Local).AddTicks(1297), "AQAAAAEAACcQAAAAEO9rKniuDAJcUbSxuVAr+AMzCJxrNurufW9d9cvIn5pXYlkSBea8SK7TmGrFL8kVbA==", "2d45171a-6545-4f4e-8629-c42b2624a375" });

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
            migrationBuilder.AddColumn<int>(
                name: "UtentesId",
                table: "Pagamentos",
                type: "int",
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
    }
}
