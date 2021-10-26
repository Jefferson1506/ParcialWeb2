using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Personas",
                newName: "tipoIdentificacion");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInfraccion",
                table: "Infracciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonaIdentificacion",
                table: "Infracciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Infracciones_PersonaIdentificacion",
                table: "Infracciones",
                column: "PersonaIdentificacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Infracciones_Personas_PersonaIdentificacion",
                table: "Infracciones",
                column: "PersonaIdentificacion",
                principalTable: "Personas",
                principalColumn: "Identificacion",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infracciones_Personas_PersonaIdentificacion",
                table: "Infracciones");

            migrationBuilder.DropIndex(
                name: "IX_Infracciones_PersonaIdentificacion",
                table: "Infracciones");

            migrationBuilder.DropColumn(
                name: "FechaInfraccion",
                table: "Infracciones");

            migrationBuilder.DropColumn(
                name: "PersonaIdentificacion",
                table: "Infracciones");

            migrationBuilder.RenameColumn(
                name: "tipoIdentificacion",
                table: "Personas",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
