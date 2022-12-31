using Microsoft.EntityFrameworkCore.Migrations;

namespace PMISBLayer.Data.Migrations
{
    public partial class AddUnqKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectPhases_ProjectId",
                table: "ProjectPhases");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhases_ProjectId_PhaseId",
                table: "ProjectPhases",
                columns: new[] { "ProjectId", "PhaseId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectPhases_ProjectId_PhaseId",
                table: "ProjectPhases");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhases_ProjectId",
                table: "ProjectPhases",
                column: "ProjectId");
        }
    }
}
