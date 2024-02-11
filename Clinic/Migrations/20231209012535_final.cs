using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7dcfbb3c-5ca3-4dac-a78a-8bd984a2cc84", "6d218988-d6bb-4b80-8aee-acf846daad0f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "970cafb7-19b1-44f7-b049-470da43e8dac", "6d218988-d6bb-4b80-8aee-acf846daad0f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab32a7e8-7252-4500-8cb5-ad5c11522d6f", "6d218988-d6bb-4b80-8aee-acf846daad0f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b29db713-b2a2-4114-bfb6-d6653280e9d0", "6d218988-d6bb-4b80-8aee-acf846daad0f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7a96128-02a7-4ab3-baa6-48e3bd2a4c7a", "6d218988-d6bb-4b80-8aee-acf846daad0f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dcfbb3c-5ca3-4dac-a78a-8bd984a2cc84");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a259adc-a16f-466e-8da6-06214a9f6803", 0, "fa6619ad-e7a8-42cc-bcaf-cadb75511903", "admin@clinic.com", false, false, null, "ADMIN@CLINIC.COM", "ADMIN@CLINIC.COM", "AQAAAAIAAYagAAAAEDQB3mSreXVqQssuEwgpBZ6qmX/Fo4uEVHAAVazM0YBG9g5HdiNRnQ5HohU9b88jPQ==", null, false, "f2f32b7c-60af-4a96-9955-799f934b811c", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f7a96128-02a7-4ab3-baa6-48e3bd2a4c7a", "7a259adc-a16f-466e-8da6-06214a9f6803" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7a96128-02a7-4ab3-baa6-48e3bd2a4c7a", "7a259adc-a16f-466e-8da6-06214a9f6803" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dcfbb3c-5ca3-4dac-a78a-8bd984a2cc84", "7dcfbb3c-5ca3-4dac-a78a-8bd984a2cc84", "SuperAdmin", "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d218988-d6bb-4b80-8aee-acf846daad0f", 0, "6ac9137b-04ab-4423-ae46-47df88133d9e", "superadmin@clinic.com", false, false, null, "SUPERADMIN@CLINIC.COM", "SUPERADMIN@CLINIC.COM", "AQAAAAIAAYagAAAAELCIKDNawaUdQOVI0ddo3abZWQC1a3MhdOTxo5mrT61OasG/JFe4JRdybztbDzL92Q==", null, false, "2a45263d-3d2d-46a7-a746-10179ae91e84", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7dcfbb3c-5ca3-4dac-a78a-8bd984a2cc84", "6d218988-d6bb-4b80-8aee-acf846daad0f" },
                    { "970cafb7-19b1-44f7-b049-470da43e8dac", "6d218988-d6bb-4b80-8aee-acf846daad0f" },
                    { "ab32a7e8-7252-4500-8cb5-ad5c11522d6f", "6d218988-d6bb-4b80-8aee-acf846daad0f" },
                    { "b29db713-b2a2-4114-bfb6-d6653280e9d0", "6d218988-d6bb-4b80-8aee-acf846daad0f" },
                    { "f7a96128-02a7-4ab3-baa6-48e3bd2a4c7a", "6d218988-d6bb-4b80-8aee-acf846daad0f" }
                });
        }
    }
}
