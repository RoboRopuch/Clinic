using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class madepatientfkinvisitsnullale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8ef36d8-f7ad-4da3-98f0-408ab377cd82", "AQAAAAIAAYagAAAAENiH1ZmoADB/QNOZzKpvYezIl+gZ3+tDV1UZFu1SQaRoTIuNdVihI63Xk4y3LBDO6g==", "4616f03e-dee9-4e2a-b28a-7d0d20a00640" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9494fba1-f0a1-4217-888e-4b01b69b533c", "AQAAAAIAAYagAAAAEPsDBC39+yQHsFaWrDdAFMVaOIcr4t+hC2BfQyAmsFs0f+t4n6lVdJkA6c2oeYxrAA==", "f93252e4-2ccf-4adb-9aff-e8e3980269c4" });
        }
    }
}
