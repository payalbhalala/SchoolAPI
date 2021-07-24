using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICourseSectionRepository
    {
        IEnumerable<CourseSection> GetAllCourseSections(bool trackChanges);

        CourseSection GetCourseSection(Guid companyId, bool trackChanges);

        void CreateCourseSection(CourseSection CourseSection);

        IEnumerable<CourseSection> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteCourseSection(CourseSection CourseSection);
    }
}