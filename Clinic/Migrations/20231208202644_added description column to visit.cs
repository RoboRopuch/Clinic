using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class addeddescriptioncolumntovisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ac9137b-04ab-4423-ae46-47df88133d9e", "AQAAAAIAAYagAAAAELCIKDNawaUdQOVI0ddo3abZWQC1a3MhdOTxo5mrT61OasG/JFe4JRdybztbDzL92Q==", "2a45263d-3d2d-46a7-a746-10179ae91e84" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Visits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be79da60-ea97-40eb-aa7f-2d9c0767b7a1", "AQAAAAIAAYagAAAAEAASTnTmLAw2srDJDUfBfEDMvCAPbQHE1xPPqY7QkkqHJbg8+Wj4+a/7ncVt7lYy2A==", "17c06b40-80b0-4f27-9e25-e5d89d24a030" });
        }
    }
}
