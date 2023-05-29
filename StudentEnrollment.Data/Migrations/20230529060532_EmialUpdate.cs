using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f55dc54-68c9-443e-a44c-526d6a64a061",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b3f4767-291b-4b3e-b742-91557ccbe8a7", "SCHOOLADMIN@LOCALHOST.COM", "SCHOOLADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEANim45UR60sSajif4EW0NHjgesYL+Y0uOx9QD5oIVJMd95F4nS/yd7UxYXOtGSDUg==", "7e5bb307-d604-40b9-82c5-904729e9d7b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f9670f9-b286-4222-bf59-e99dc37511f4",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfe76a27-2e39-4e56-b454-48bc9f9bfec2", "SCHOOLUSER@LOCALHOST.COM", "SCHOOLUSER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFiIPz/k4/kTr8o6StuHueJluwn3+MYOlIMy4hKUhHFgNQvIemwAIdgcf3YuabcNCw==", "6bdc1dff-aba5-4796-b0bd-18683f240cad" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f55dc54-68c9-443e-a44c-526d6a64a061",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "544786a8-633d-45b8-91ec-ab1887e0b9ae", "SCHOOLADMIN@LOCAHOST.COM", "SCHOOLADMIN@LOCAHOST.COM", "AQAAAAIAAYagAAAAEPphZ4rWoKBA++RubmcBWs7pWcDg3S5BNrmlyUySMAPHhrZ4ZBPFDQrMQM8DlhjZbw==", "94440426-a728-412e-ac30-bf74ed619bc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f9670f9-b286-4222-bf59-e99dc37511f4",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5192523f-d2ed-4a70-bec1-abb2d0da514c", "SCHOOLUSER@LOCAHOST.COM", "SCHOOLUSER@LOCAHOST.COM", "AQAAAAIAAYagAAAAEM6F/RvE7S6U75cEiPBzvDz7mxewS7boAu/KQDOnbl7VDuNg4g+jb9tl+DOqkhg+bQ==", "a893d002-df8a-46c1-bcd9-d1ff809b193b" });
        }
    }
}
