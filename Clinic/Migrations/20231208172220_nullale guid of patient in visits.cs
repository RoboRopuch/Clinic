using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class nullaleguidofpatientinvisits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be79da60-ea97-40eb-aa7f-2d9c0767b7a1", "AQAAAAIAAYagAAAAEAASTnTmLAw2srDJDUfBfEDMvCAPbQHE1xPPqY7QkkqHJbg8+Wj4+a/7ncVt7lYy2A==", "17c06b40-80b0-4f27-9e25-e5d89d24a030" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d218988-d6bb-4b80-8aee-acf846daad0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5273a393-f195-4ece-9c95-3f1b934b1eca", "AQAAAAIAAYagAAAAEEk4cihDOOSBKA1ZDZPrdJ+KycIUfGOYZc16FZG5zrEPsDS+JGUE6ClX2X8A7O3FFg==", "02266ce1-b9b6-4f62-b7e7-4c79dad303ce" });
        }
    }
}
