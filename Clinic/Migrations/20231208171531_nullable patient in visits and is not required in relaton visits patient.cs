using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class nullablepatientinvisitsandisnotrequiredinrelatonvisitspatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a303b46a-769a-4b30-8ece-9d335b560ded", "AQAAAAIAAYagAAAAEJtPb3f7CCLWY6gw8nBl5fyzG5sB248cCuzpPGnaSnOinIpGXbMUrT1MIJ2IQ+P/PA==", "8456896b-e91a-41e7-a0f6-7a5ba72ecc3f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8ef36d8-f7ad-4da3-98f0-408ab377cd82", "AQAAAAIAAYagAAAAENiH1ZmoADB/QNOZzKpvYezIl+gZ3+tDV1UZFu1SQaRoTIuNdVihI63Xk4y3LBDO6g==", "4616f03e-dee9-4e2a-b28a-7d0d20a00640" });
        }
    }
}
