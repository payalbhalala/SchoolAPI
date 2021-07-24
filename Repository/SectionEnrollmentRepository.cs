using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class SectionEnrollmentRepository : RepositoryBase<SectionEnrollment>, ISectionEnrollmentRepository
    {
        public SectionEnrollmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<SectionEnrollment> GetAllSectionEnrollments(bool trackChanges) =>
          FindAll(trackChanges)
          .OrderBy(c => c.SectionId)
          .ToList();

        public SectionEnrollment GetSectionEnrollment(Guid companyId, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(companyId), trackChanges)
        .SingleOrDefault();

        public void CreateSectionEnrollment(SectionEnrollment SectionEnrollment) => Create(SectionEnrollment);

        public IEnumerable<SectionEnrollment> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToList();

        public void DeleteSectionEnrollment(SectionEnrollment SectionEnrollment)
        {
            Delete(SectionEnrollment);
        }
    }
}