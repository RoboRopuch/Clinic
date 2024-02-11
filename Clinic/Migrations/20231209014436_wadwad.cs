using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class wadwad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db5eb002-58b3-4368-9d35-bc821e47878f", "AQAAAAIAAYagAAAAEFcxn2agtuoi0BneE7S96jkAkGKA7jXSaGGHRBVs+oebTTukFXB76gp+1c+jQVS2gQ==", "64c64364-3858-4a3d-84dc-61bddd39578c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa6619ad-e7a8-42cc-bcaf-cadb75511903", "AQAAAAIAAYagAAAAEDQB3mSreXVqQssuEwgpBZ6qmX/Fo4uEVHAAVazM0YBG9g5HdiNRnQ5HohU9b88jPQ==", "f2f32b7c-60af-4a96-9955-799f934b811c" });
        }
    }
}
