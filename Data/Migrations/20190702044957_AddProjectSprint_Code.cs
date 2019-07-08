using Microsoft.EntityFrameworkCore.Migrations;

namespace NewAssignment2019.Data.Migrations
{
    public partial class AddProjectSprint_Code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProjectSprint",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProjectSprint");
        }
    }
}
