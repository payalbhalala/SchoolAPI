using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CourseAssignmentRepository : RepositoryBase<CourseAssignment>, ICourseAssignmentRepository
    {
        public CourseAssignmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<CourseAssignment> GetAllCourseAssignments(bool trackChanges) =>
          FindAll(trackChanges)
          .OrderBy(c => c.Assignmenttitle)
          .ToList();

        public CourseAssignment GetCourseAssignment(Guid companyId, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(companyId), trackChanges)
        .SingleOrDefault();

        public void CreateCourseAssignment(CourseAssignment CourseAssignment) => Create(CourseAssignment);

        public IEnumerable<CourseAssignment> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToList();

        public void DeleteCourseAssignment(CourseAssignment CourseAssignment)
        {
            Delete(CourseAssignment);
        }
    }
}