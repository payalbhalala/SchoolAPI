using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SectionEnrollmentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseSectionConfiguration());
            modelBuilder.ApplyConfiguration(new CourseManagementConfiguration());
            modelBuilder.ApplyConfiguration(new CourseAssignmentConfiguration());
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SectionEnrollment> SectionEnrollments { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<CourseSection> CourseManagements { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
    }
}   
