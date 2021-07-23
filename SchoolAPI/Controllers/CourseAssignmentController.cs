using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Controllers
{
    [Route("api/v1/CourseAssignments")]
    [ApiController]
    public class CourseAssignmentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CourseAssignmentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCourseAssignments()
        {
            try
            {
                var CourseAssignments = _repository.CourseAssignment.GetAllCourseAssignments(trackChanges: false);
                return Ok(CourseAssignments);
                /*var CourseAssignmentDto = _mapper.Map<IEnumerable<CourseAssignmentDto>>(CourseAssignments);
                return Ok(CourseAssignmentDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourseAssignments)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCourseAssignmenty(Guid id)
        {
            try
            {
                var CourseAssignment = _repository.CourseAssignment.GetCourseAssignment(id, trackChanges: false); if (CourseAssignment == null)
                {
                    _logger.LogInfo($"CourseAssignment with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var CourseAssignmentDto = _mapper.Map<CourseAssignmentDto>(CourseAssignment);
                    return Ok(CourseAssignmentDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourseAssignments)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}

