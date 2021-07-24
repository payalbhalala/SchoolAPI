using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Organization, OrganizationDto>()
                    .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => string.Join(' ', x.City, x.Country)));
            
            CreateMap<OrganizationForCreationDto, Organization>();
            CreateMap<OrganizationForUpdateDto, Organization>();

            CreateMap<User, UserDto>()
                    .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => string.Join(' ', x .Email, x.Name)));

            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();


            CreateMap<SectionEnrollment, SectionEnrollmentDto>()
                    .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => string.Join(' ', x.SectionId)));

            CreateMap<SectionEnrollmentForCreationDto, SectionEnrollment>();
            CreateMap<SectionEnrollmentForUpdateDto, SectionEnrollment>();

            CreateMap<CourseSection, CourseSectionDto>()
                    .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => string.Join(' ', x.CourseId)));

            CreateMap<CourseSectionForCreationDto, CourseSection>();
            CreateMap<CourseSectionForUpdateDto, CourseSection>();

            CreateMap<CourseManagement, CourseManagementDto>()
                    .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => string.Join(' ', x.Coursetitle)));

            CreateMap<CourseManagementForCreationDto, CourseManagement>();
            CreateMap<CourseManagementForUpdateDto, CourseManagement>();

            CreateMap<CourseAssignment, CourseAssignmentDto>()
                    .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => string.Join(' ', x.Assignmenttitle)));

            CreateMap<CourseAssignmentForCreationDto, CourseAssignment>();
            CreateMap<CourseAssignmentForUpdateDto, CourseAssignment>();
        }
    }
}