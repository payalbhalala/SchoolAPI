using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CourseAssignmentRepository : RepositoryBase<CourseAssignment>, ICourseAssignmentRepository
    {
        public CourseAssignmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}