using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class addedtimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Visits",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f653701-588e-4586-ab2c-42b2e6f5570d", "AQAAAAIAAYagAAAAEIr/UMX7K10k/8/3CcGBJp55RUkIP9TTBdslxlthJeFUV0FFiiTh2bntr2NBuX7YPg==", "22f4cabf-e731-47c5-9fc8-12f7d3f33d47" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Visits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a259adc-a16f-466e-8da6-06214a9f6803",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad82ada3-e080-4ae7-ad94-9bd0cad0d74b", "AQAAAAIAAYagAAAAEBKhPQaYFNTheEPqRhxcGrEGdzRp3zIh0eYWFzt/CxEz8TFX+uJM9gyhHQsTD6v4xw==", "8c0e01f8-8133-4dac-8d26-e179a0ef2b96" });
        }
    }
}
