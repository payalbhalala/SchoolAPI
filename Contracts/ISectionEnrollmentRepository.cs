using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ISectionEnrollmentRepository
    {
        IEnumerable<SectionEnrollment> GetAllSectionEnrollments(bool trackChanges);

        SectionEnrollment GetSectionEnrollment(Guid companyId, bool trackChanges);

        void CreateSectionEnrollment(SectionEnrollment SectionEnrollment);

        IEnumerable<SectionEnrollment> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteSectionEnrollment(SectionEnrollment SectionEnrollment);
    }
}