using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserAndRoleAssigments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af2c0f9b-c8b6-446c-afdf-f2abb2935a66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdc7d100-78a8-4f6a-b8d8-ee52d8de6315");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "581a8514-de3d-42f8-be90-5497c4411055", null, "User", "USER" },
                    { "7a7f98ed-9e6f-491e-ac1c-7f10e40378c2", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2f55dc54-68c9-443e-a44c-526d6a64a061", 0, "544786a8-633d-45b8-91ec-ab1887e0b9ae", "schooladmin@localhost.com", true, "School", "Admin", false, null, "SCHOOLADMIN@LOCAHOST.COM", "SCHOOLADMIN@LOCAHOST.COM", "AQAAAAIAAYagAAAAEPphZ4rWoKBA++RubmcBWs7pWcDg3S5BNrmlyUySMAPHhrZ4ZBPFDQrMQM8DlhjZbw==", null, false, "94440426-a728-412e-ac30-bf74ed619bc8", false, "schooladmin@localhost.com" },
                    { "8f9670f9-b286-4222-bf59-e99dc37511f4", 0, "5192523f-d2ed-4a70-bec1-abb2d0da514c", "schooluser@localhost.com", true, "School", "User", false, null, "SCHOOLUSER@LOCAHOST.COM", "SCHOOLUSER@LOCAHOST.COM", "AQAAAAIAAYagAAAAEM6F/RvE7S6U75cEiPBzvDz7mxewS7boAu/KQDOnbl7VDuNg4g+jb9tl+DOqkhg+bQ==", null, false, "a893d002-df8a-46c1-bcd9-d1ff809b193b", false, "schooluser@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7a7f98ed-9e6f-491e-ac1c-7f10e40378c2", "2f55dc54-68c9-443e-a44c-526d6a64a061" },
                    { "581a8514-de3d-42f8-be90-5497c4411055", "8f9670f9-b286-4222-bf59-e99dc37511f4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7a7f98ed-9e6f-491e-ac1c-7f10e40378c2", "2f55dc54-68c9-443e-a44c-526d6a64a061" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "581a8514-de3d-42f8-be90-5497c4411055", "8f9670f9-b286-4222-bf59-e99dc37511f4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "581a8514-de3d-42f8-be90-5497c4411055");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a7f98ed-9e6f-491e-ac1c-7f10e40378c2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f55dc54-68c9-443e-a44c-526d6a64a061");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f9670f9-b286-4222-bf59-e99dc37511f4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "af2c0f9b-c8b6-446c-afdf-f2abb2935a66", null, "Administrator", "ADMINISTRATOR" },
                    { "cdc7d100-78a8-4f6a-b8d8-ee52d8de6315", null, "User", "USER" }
                });
        }
    }
}
