using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class AddingCoursesection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseSection",
                columns: new[] { "CourseSectionId", "OrganizationId", "UserName" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479812"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kevinp" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseSection",
                keyColumn: "CourseSectionId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479812"));
        }
    }
}
