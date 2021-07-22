using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CourseSectionRepository : RepositoryBase<CourseSection>, ICourseSectionRepository
    {
        public CourseSectionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}