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
          .OrderBy(c => c.Coursetitle)
          .ToList();

        public CourseManagement GetCourseManagement(Guid companyId, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(companyId), trackChanges)
        .SingleOrDefault();

        public void CreateCourseManagement(CourseManagement CourseManagement) => Create(CourseManagement);

        public IEnumerable<CourseManagement> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToList();

        public void DeleteCourseManagement(CourseManagement CourseManagement)
        {
            Delete(CourseManagement);
        }
    }
}