using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreandoTablaCiudades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_CiudadId",
                table: "Personas",
                column: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ciudades_CiudadId",
                table: "Personas",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ciudades_CiudadId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Personas_CiudadId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "Personas");
        }
    }
}
