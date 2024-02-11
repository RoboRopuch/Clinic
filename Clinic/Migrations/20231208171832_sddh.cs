using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class sddh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5273a393-f195-4ece-9c95-3f1b934b1eca", "AQAAAAIAAYagAAAAEEk4cihDOOSBKA1ZDZPrdJ+KycIUfGOYZc16FZG5zrEPsDS+JGUE6ClX2X8A7O3FFg==", "02266ce1-b9b6-4f62-b7e7-4c79dad303ce" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a303b46a-769a-4b30-8ece-9d335b560ded", "AQAAAAIAAYagAAAAEJtPb3f7CCLWY6gw8nBl5fyzG5sB248cCuzpPGnaSnOinIpGXbMUrT1MIJ2IQ+P/PA==", "8456896b-e91a-41e7-a0f6-7a5ba72ecc3f" });
        }
    }
}
