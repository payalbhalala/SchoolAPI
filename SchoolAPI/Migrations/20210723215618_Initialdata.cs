using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class Initialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(nullable: false),
                    OrgName = table.Column<string>(maxLength: 60, nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
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
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Assignmenttitle = table.Column<string>(nullable: true),
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
                    Coursetitle = table.Column<string>(nullable: true),
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
                    CourseId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CourseSection_CourseId = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSection", x => x.CourseId);
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
                    SectionEnrollmentId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SectionId = table.Column<string>(nullable: true),
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
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
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
                columns: new[] { "OrganizationId", "City", "Country", "OrgName" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Bloomfield", "USA", "XYZ org" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "City", "Country", "OrgName" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Lusaka", "ZM", "lmnop org" });

            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "CourseAssignmentId", "Assignmenttitle", "Email", "Name", "OrganizationId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Calender", null, null, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pbhalala" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Calculator", null, null, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "payalk" }
                });

            migrationBuilder.InsertData(
                table: "CourseManagement",
                columns: new[] { "CourseManagementId", "Coursetitle", "OrganizationId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Web Systems Development", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pbhalala" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Accounting", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "payalk" }
                });

            migrationBuilder.InsertData(
                table: "CourseSection",
                columns: new[] { "CourseId", "CourseSection_CourseId", "Email", "Name", "OrganizationId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "123 098", "kp12@njit.edu", "Nirav", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pbhalala" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "765 346", "pk56@njit.edu", "Kevin", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "payalk" }
                });

            migrationBuilder.InsertData(
                table: "SectionEnrollments",
                columns: new[] { "SectionEnrollmentId", "Email", "Name", "OrganizationId", "SectionId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "kp12@njit.edu", "Nirav", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "123", "pbhalala" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "pk56@njit.edu", "Kevin", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "098", "payalk" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "OrganizationId", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "kp12@njit.edu", "Nirav", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pbhalala" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "nc34@njit.edu", "Payal", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "pkevin" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "pk56@njit.edu", "Kevin", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "payalk" }
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
