using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class Initialdatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(nullable: false),
                    OrgName = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                columns: table => new
                {
                    CourseAssignmentId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignments", x => x.CourseAssignmentId);
                    table.ForeignKey(
                        name: "FK_CourseAssignments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseManagement",
                columns: table => new
                {
                    CourseManagementId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseManagement", x => x.CourseManagementId);
                    table.ForeignKey(
                        name: "FK_CourseManagement_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSection",
                columns: table => new
                {
                    CourseSectionId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSection", x => x.CourseSectionId);
                    table.ForeignKey(
                        name: "FK_CourseSection_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionEnrollments",
                columns: table => new
                {
                    SectionEnrollmentId = table.Column<Guid>(name: "SectionEnrollment Id", nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionEnrollments", x => x.SectionEnrollmentId);
                    table.ForeignKey(
                        name: "FK_SectionEnrollments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "OrgName" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "ABC org" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "OrgName" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "NPV org" });

            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "CourseAssignmentId", "OrganizationId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pbhalala" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pkevin" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "payalk" }
                });

            migrationBuilder.InsertData(
                table: "CourseManagement",
                columns: new[] { "CourseManagementId", "OrganizationId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pbhalala" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pkevin" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "payalk" }
                });

            migrationBuilder.InsertData(
                table: "CourseSection",
                columns: new[] { "CourseSectionId", "OrganizationId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pbhalala" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pkevin" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "payalk" }
                });

            migrationBuilder.InsertData(
                table: "SectionEnrollments",
                columns: new[] { "SectionEnrollment Id", "OrganizationId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pbhalala" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pkevin" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "payalk" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "OrganizationId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pbhalala" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pkevin" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "payalk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_OrganizationId",
                table: "CourseAssignments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagement_OrganizationId",
                table: "CourseManagement",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSection_OrganizationId",
                table: "CourseSection",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrollments_OrganizationId",
                table: "SectionEnrollments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignments");

            migrationBuilder.DropTable(
                name: "CourseManagement");

            migrationBuilder.DropTable(
                name: "CourseSection");

            migrationBuilder.DropTable(
                name: "SectionEnrollments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
