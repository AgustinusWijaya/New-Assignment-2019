using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewAssignment2019.Data.Migrations
{
    public partial class RenameProjectWBStoProjectFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectWBS");

            migrationBuilder.CreateTable(
                name: "ProjectFeature",
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
                    table.PrimaryKey("PK_ProjectFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFeature_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSprint",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    DateBegin = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSprint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSprint_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFeature_ProjectId",
                table: "ProjectFeature",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSprint_ProjectId",
                table: "ProjectSprint",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFeature");

            migrationBuilder.DropTable(
                name: "ProjectSprint");

            migrationBuilder.CreateTable(
                name: "ProjectWBS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 15, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    IsLeaf = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ParentCode = table.Column<string>(maxLength: 15, nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWBS", x => x.Id);
                });
        }
    }
}
