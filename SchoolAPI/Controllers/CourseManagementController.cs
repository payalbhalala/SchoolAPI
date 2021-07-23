using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Controllers
{
    [Route("api/v1/CourseManagements")]
    [ApiController]
    public class CourseManagementsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CourseManagementsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCourseManagements()
        {
            try
            {
                var CourseManagements = _repository.CourseManagement.GetAllCourseManagements(trackChanges: false);
                return Ok(CourseManagements);
                /*var CourseManagementDto = _mapper.Map<IEnumerable<CourseManagementDto>>(CourseManagements);
                return Ok(CourseManagementDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourseManagements)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCourseManagementy(Guid id)
        {
            try
            {
                var CourseManagement = _repository.CourseManagement.GetCourseManagement(id, trackChanges: false); if (CourseManagement == null)
                {
                    _logger.LogInfo($"CourseManagement with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var CourseManagementDto = _mapper.Map<CourseManagementDto>(CourseManagement);
                    return Ok(CourseManagementDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourseManagements)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
