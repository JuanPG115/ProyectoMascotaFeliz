using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotaFeliz.App.Persistencia.Migrations
{
    public partial class objectVeterinario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdVeterinario",
                table: "VisitasPyP");

            migrationBuilder.AddColumn<int>(
                name: "VeterinarioId",
                table: "VisitasPyP",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitasPyP_VeterinarioId",
                table: "VisitasPyP",
                column: "VeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitasPyP_Personas_VeterinarioId",
                table: "VisitasPyP",
                column: "VeterinarioId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitasPyP_Personas_VeterinarioId",
                table: "VisitasPyP");

            migrationBuilder.DropIndex(
                name: "IX_VisitasPyP_VeterinarioId",
                table: "VisitasPyP");

            migrationBuilder.DropColumn(
                name: "VeterinarioId",
                table: "VisitasPyP");

            migrationBuilder.AddColumn<int>(
                name: "IdVeterinario",
                table: "VisitasPyP",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
