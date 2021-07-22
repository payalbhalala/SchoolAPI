namespace Contracts
{
    public interface IRepositoryManager
    {
        IOrganizationRepository Organization { get; }
        IUserRepository User { get; }
        ISectionEnrollmentRepository SectionEnrollment { get; }
        ICourseSectionRepository CourseSection { get; }
        ICourseManagementRepository CourseManagement { get; }
        ICourseAssignmentRepository CourseAssignment { get; }

        void Save();
    }
}