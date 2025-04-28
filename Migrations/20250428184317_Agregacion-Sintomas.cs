using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial_1__Programacion.Migrations
{
    /// <inheritdoc />
    public partial class AgregacionSintomas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sintomas",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sintomas",
                table: "Pacientes");
        }
    }
}
