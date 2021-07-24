using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICourseManagementRepository
    {
        IEnumerable<CourseManagement> GetAllCourseManagements(bool trackChanges);

        CourseManagement GetCourseManagement(Guid companyId, bool trackChanges);

        void CreateCourseManagement(CourseManagement CourseManagement);

        IEnumerable<CourseManagement> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteCourseManagement(CourseManagement CourseManagement);
    }
}