using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
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

        [HttpGet(Name = "getAllCourseAssignments")]
        public IActionResult GetCourseAssignments()
        {
            var CourseAssignments = _repository.CourseAssignment.GetAllCourseAssignments(trackChanges: false);

            var CourseAssignmentDto = _mapper.Map<IEnumerable<CourseAssignmentDto>>(CourseAssignments);
            //uncomment the code below to test the global exception handling
            //throw new Exception("Exception");
            return Ok(CourseAssignmentDto);
        }

        [HttpGet("{id}", Name = "getCourseAssignmentById")]
        public IActionResult GetCourseAssignment(Guid id)
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

        [HttpPost(Name = "createCourseAssignment")]
        public IActionResult CreateCourseAssignment([FromBody] CourseAssignmentForCreationDto CourseAssignment)
        {
            if (CourseAssignment == null)
            {
                _logger.LogError("CourseAssignment ForCreationDto object sent from client is null.");
                return BadRequest("CourseAssignment ForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseAssignmentForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var CourseAssignmentEntity = _mapper.Map<CourseAssignment>(CourseAssignment);

            _repository.CourseAssignment.CreateCourseAssignment(CourseAssignmentEntity);
            _repository.Save();

            var CourseAssignmentToReturn = _mapper.Map<CourseAssignmentDto>(CourseAssignmentEntity);

            return CreatedAtRoute("getCourseAssignmentById", new { id = CourseAssignmentToReturn.Id }, CourseAssignmentToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourseAssignment(Guid id, [FromBody] CourseAssignmentForUpdateDto CourseAssignment)
        {
            if (CourseAssignment == null)
            {
                _logger.LogError("CourseAssignmentForUpdateDto object sent from client is null.");
                return BadRequest("CourseAssignmentForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseAssignmentForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var CourseAssignmentEntity = _repository.CourseAssignment.GetCourseAssignment(id, trackChanges: true);
            if (CourseAssignmentEntity == null)
            {
                _logger.LogInfo($"CourseAssignment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(CourseAssignment, CourseAssignmentEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourseAssignment(Guid id)
        {
            var CourseAssignment = _repository.CourseAssignment.GetCourseAssignment(id, trackChanges: false);
            if (CourseAssignment == null)
            {
                _logger.LogInfo($"Organiation with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.CourseAssignment.DeleteCourseAssignment(CourseAssignment);
            _repository.Save();

            return NoContent();
        }
    }
}