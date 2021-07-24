using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class CourseManagementConfiguration : IEntityTypeConfiguration<CourseManagement>
    {
        public void Configure(EntityTypeBuilder<CourseManagement> builder)
        {
            builder.HasData
            (
                new CourseManagement
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),

                    OrganizationId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    UserName = "pbhalala",
                    Coursetitle = "Web Systems Development"


                },
                
                 new CourseManagement
                 {
                     Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                     OrganizationId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                     UserName = "payalk",
                     Coursetitle = "Accounting"
                 }
            );
        }
    }
}