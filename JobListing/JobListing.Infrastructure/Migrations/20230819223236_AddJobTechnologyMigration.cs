using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobListing.Infrastructure.Migrations
{
    public partial class AddJobTechnologyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobsTechnologies",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsTechnologies", x => new { x.JobId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_JobsTechnologies_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobsTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobsTechnologies_TechnologyId",
                table: "JobsTechnologies",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobsTechnologies");
        }
    }
}
