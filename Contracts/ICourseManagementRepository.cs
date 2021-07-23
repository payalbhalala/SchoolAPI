using Entities.Models;
using System;
using System.Collections.Generic;



namespace Contracts
{
    public interface ICourseManagementRepository
    {
        IEnumerable<CourseManagement> GetAllCourseManagements(bool trackChanges);
        CourseManagement GetCourseManagement(Guid companyId, bool trackChanges);
    }
}