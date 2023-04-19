using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonasWeb.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ciudad",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Persona",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Persona");
        }
    }
}
