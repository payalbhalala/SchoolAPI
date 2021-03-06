using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class CourseSectionConfiguration : IEntityTypeConfiguration<CourseSection>
    {
        public void Configure(EntityTypeBuilder<CourseSection> builder)
        {
            builder.HasData
            (
                new CourseSection
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    UserName = "pbhalala",
                    OrganizationId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Email = "kp12@njit.edu",
                    Name = "Nirav",
                    CourseId = "123 098"


                },
                
                 new CourseSection
                 {
                     Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                     UserName = "payalk",
                     OrganizationId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                     Email = "pk56@njit.edu",
                     Name = "Kevin",
                     CourseId = "765 346"
                 }
            );
        }
    }
}