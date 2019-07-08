using Microsoft.EntityFrameworkCore.Migrations;

namespace NewAssignment2019.Data.Migrations
{
    public partial class UpdateProjectSprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSprint_Project_ProjectId",
                table: "ProjectSprint");

            migrationBuilder.DropIndex(
                name: "IX_ProjectSprint_ProjectId",
                table: "ProjectSprint");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectSprint",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectSprint",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "IX_UniqueCode",
                table: "ProjectSprint",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "IX_UniqueName",
                table: "ProjectSprint",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "IX_UniqueCode",
                table: "ProjectSprint");

            migrationBuilder.DropUniqueConstraint(
                name: "IX_UniqueName",
                table: "ProjectSprint");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectSprint");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectSprint",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSprint_ProjectId",
                table: "ProjectSprint",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSprint_Project_ProjectId",
                table: "ProjectSprint",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
