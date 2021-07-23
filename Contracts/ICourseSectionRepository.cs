using Entities.Models;
using System;
using System.Collections.Generic;



namespace Contracts
{
    public interface ICourseSectionRepository
    {
        IEnumerable<CourseSection> GetAllCourseSections(bool trackChanges);
        CourseSection GetCourseSection(Guid companyId, bool trackChanges);
    }
}