using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class SectionEnrollmentRepository : RepositoryBase<SectionEnrollment>, ISectionEnrollmentRepository
    {
        public SectionEnrollmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}