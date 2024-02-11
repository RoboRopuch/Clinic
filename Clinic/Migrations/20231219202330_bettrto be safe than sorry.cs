using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class bettrtobesafethansorry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ce05321-430f-4487-a819-28f9fadab022", "AQAAAAIAAYagAAAAEGoBtzIRaVA21ksOuFBeE+EjvXsJ91BTWEo2gD5PSlt5Tv5lA1zl/OGg2YUp/b2KFw==", "f6b94a14-a647-4343-ac2e-fa90a7ca86f0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f2f3240-09d2-4c7c-9ac1-7fc945722b8f", "AQAAAAIAAYagAAAAECl2jWKwOMSxxq5wEPGqRJ3JKEnphdPJuVZGbWYmpagjareNNBrlNRs+Z/2+V//rHg==", "eef58e16-d83c-4183-a35e-2c8776da124c" });
        }
    }
}
