using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
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

        [HttpGet(Name = "getAllCourseManagements")]
        public IActionResult GetCourseManagements()
        {
            var CourseManagements = _repository.CourseManagement.GetAllCourseManagements(trackChanges: false);

            var CourseManagementDto = _mapper.Map<IEnumerable<CourseManagementDto>>(CourseManagements);
            //uncomment the code below to test the global exception handling
            //throw new Exception("Exception");
            return Ok(CourseManagementDto);
        }

        [HttpGet("{id}", Name = "getCourseManagementById")]
        public IActionResult GetCourseManagement(Guid id)
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

        [HttpPost(Name = "createCourseManagement")]
        public IActionResult CreateCourseManagement([FromBody] CourseManagementForCreationDto CourseManagement)
        {
            if (CourseManagement == null)
            {
                _logger.LogError("CourseManagement ForCreationDto object sent from client is null.");
                return BadRequest("CourseManagement ForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseManagementForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var CourseManagementEntity = _mapper.Map<CourseManagement>(CourseManagement);

            _repository.CourseManagement.CreateCourseManagement(CourseManagementEntity);
            _repository.Save();

            var CourseManagementToReturn = _mapper.Map<CourseManagementDto>(CourseManagementEntity);

            return CreatedAtRoute("getCourseManagementById", new { id = CourseManagementToReturn.Id }, CourseManagementToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourseManagement(Guid id, [FromBody] CourseManagementForUpdateDto CourseManagement)
        {
            if (CourseManagement == null)
            {
                _logger.LogError("CourseManagementForUpdateDto object sent from client is null.");
                return BadRequest("CourseManagementForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseManagementForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var CourseManagementEntity = _repository.CourseManagement.GetCourseManagement(id, trackChanges: true);
            if (CourseManagementEntity == null)
            {
                _logger.LogInfo($"CourseManagement with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(CourseManagement, CourseManagementEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourseManagement(Guid id)
        {
            var CourseManagement = _repository.CourseManagement.GetCourseManagement(id, trackChanges: false);
            if (CourseManagement == null)
            {
                _logger.LogInfo($"Organiation with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.CourseManagement.DeleteCourseManagement(CourseManagement);
            _repository.Save();

            return NoContent();
        }
    }
}