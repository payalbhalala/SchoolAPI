using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CourseSectionRepository : RepositoryBase<CourseSection>, ICourseSectionRepository
    {
        public CourseSectionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<CourseSection> GetAllCourseSections(bool trackChanges) =>
          FindAll(trackChanges)
          .OrderBy(c => c.UserName)
          .ToList();

        public CourseSection GetCourseSection(Guid companyId, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(companyId), trackChanges)
        .SingleOrDefault();
    }
}