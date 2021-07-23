using Entities.Models;
using System;
using System.Collections.Generic;



namespace Contracts
{
    public interface ICourseAssignmentRepository
    {
        IEnumerable<CourseAssignment> GetAllCourseAssignments(bool trackChanges);
        CourseAssignment GetCourseAssignment(Guid companyId, bool trackChanges);
    }
}
