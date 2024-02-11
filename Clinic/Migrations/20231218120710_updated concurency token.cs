using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class updatedconcurencytoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f2f3240-09d2-4c7c-9ac1-7fc945722b8f", "AQAAAAIAAYagAAAAECl2jWKwOMSxxq5wEPGqRJ3JKEnphdPJuVZGbWYmpagjareNNBrlNRs+Z/2+V//rHg==", "eef58e16-d83c-4183-a35e-2c8776da124c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f653701-588e-4586-ab2c-42b2e6f5570d", "AQAAAAIAAYagAAAAEIr/UMX7K10k/8/3CcGBJp55RUkIP9TTBdslxlthJeFUV0FFiiTh2bntr2NBuX7YPg==", "22f4cabf-e731-47c5-9fc8-12f7d3f33d47" });
        }
    }
}
