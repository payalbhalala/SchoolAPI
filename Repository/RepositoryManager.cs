using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IOrganizationRepository _organizationRepository;
        private IUserRepository _userRepository;
        private ISectionEnrollmentRepository _SectionEnrollmentRepository;
        private ICourseSectionRepository _CourseSectionRepository;
        private ICourseManagementRepository _CourseManagementRepository;
        private ICourseAssignmentRepository _CourseAssignmentRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IOrganizationRepository Organization
        {
            get
            {
                if (_organizationRepository == null)
                    _organizationRepository = new OrganizationRepository(_repositoryContext);

                return _organizationRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);

                return _userRepository;
            }
        }

        public ISectionEnrollmentRepository SectionEnrollment
        {
            get
            {
                if (_SectionEnrollmentRepository == null)
                    _SectionEnrollmentRepository = new SectionEnrollmentRepository(_repositoryContext);

                return _SectionEnrollmentRepository;
            }
        }

        public ICourseSectionRepository CourseSection
        {
            get
            {
                if (_CourseSectionRepository == null)
                    _CourseSectionRepository = new CourseSectionRepository(_repositoryContext);

                return _CourseSectionRepository;
            }
        }

        public ICourseManagementRepository CourseManagement
        {
            get
            {
                if (_CourseManagementRepository == null)
                    _CourseManagementRepository = new CourseManagementRepository(_repositoryContext);

                return _CourseManagementRepository;
            }
        }

        public ICourseAssignmentRepository CourseAssignment
        {
            get
            {
                if (_CourseAssignmentRepository == null)
                    _CourseAssignmentRepository = new CourseAssignmentRepository(_repositoryContext);

                return _CourseAssignmentRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }
}
 