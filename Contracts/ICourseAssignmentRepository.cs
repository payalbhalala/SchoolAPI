using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICourseAssignmentRepository
    {
        IEnumerable<CourseAssignment> GetAllCourseAssignments(bool trackChanges);

        CourseAssignment GetCourseAssignment(Guid companyId, bool trackChanges);

        void CreateCourseAssignment(CourseAssignment CourseAssignment);

        IEnumerable<CourseAssignment> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteCourseAssignment(CourseAssignment CourseAssignment);
    }
}