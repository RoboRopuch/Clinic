using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class wadwdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad82ada3-e080-4ae7-ad94-9bd0cad0d74b", "ADMIN", "AQAAAAIAAYagAAAAEBKhPQaYFNTheEPqRhxcGrEGdzRp3zIh0eYWFzt/CxEz8TFX+uJM9gyhHQsTD6v4xw==", "8c0e01f8-8133-4dac-8d26-e179a0ef2b96" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db5eb002-58b3-4368-9d35-bc821e47878f", "ADMIN@CLINIC.COM", "AQAAAAIAAYagAAAAEFcxn2agtuoi0BneE7S96jkAkGKA7jXSaGGHRBVs+oebTTukFXB76gp+1c+jQVS2gQ==", "64c64364-3858-4a3d-84dc-61bddd39578c" });
        }
    }
}
