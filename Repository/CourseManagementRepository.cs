using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CourseManagementRepository : RepositoryBase<CourseManagement>, ICourseManagementRepository
    {
        public CourseManagementRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<CourseManagement> GetAllCourseManagements(bool trackChanges) =>
          FindAll(trackChanges)
          .OrderBy(c => c.UserName)
          .ToList();

        public CourseManagement GetCourseManagement(Guid companyId, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(companyId), trackChanges)
        .SingleOrDefault();
    }
}