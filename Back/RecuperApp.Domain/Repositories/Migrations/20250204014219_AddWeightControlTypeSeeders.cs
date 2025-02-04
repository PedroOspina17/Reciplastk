using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecuperApp.Domain.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddWeightControlTypeSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "weightcontroltypes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "weightcontroltypes",
                columns: new[] { "id", "createdby", "createddate", "description", "isactive", "name", "updatedby", "updateddate" },
                values: new object[,]
                {
                    { 1, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "Proceso en el que se separa el material", true, "Separacion", null, null },
                    { 2, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "Proceso en el que se muelen los materiales separados", true, "Molido", null, null },
                    { 3, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "Proceso en el que se compacta los materiales", true, "Compactado", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "weightcontroltypes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "weightcontroltypes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "weightcontroltypes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "weightcontroltypes",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
