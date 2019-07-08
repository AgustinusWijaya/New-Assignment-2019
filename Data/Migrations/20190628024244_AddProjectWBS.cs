using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewAssignment2019.Data.Migrations
{
    public partial class AddProjectWBS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectWBS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 15, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    ParentCode = table.Column<string>(maxLength: 15, nullable: true),
                    IsLeaf = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWBS", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectWBS");
        }
    }
}
