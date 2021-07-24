using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [Route("api/v1/CourseSections")]
    [ApiController]
    public class CourseSectionsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CourseSectionsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "getAllCourseSections")]
        public IActionResult GetCourseSections()
        {
            var CourseSections = _repository.CourseSection.GetAllCourseSections(trackChanges: false);

            var CourseSectionDto = _mapper.Map<IEnumerable<CourseSectionDto>>(CourseSections);
            //uncomment the code below to test the global exception handling
            //throw new Exception("Exception");
            return Ok(CourseSectionDto);
        }

        [HttpGet("{id}", Name = "getCourseSectionById")]
        public IActionResult GetCourseSection(Guid id)
        {
            var CourseSection = _repository.CourseSection.GetCourseSection(id, trackChanges: false); if (CourseSection == null)
            {
                _logger.LogInfo($"CourseSection with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var CourseSectionDto = _mapper.Map<CourseSectionDto>(CourseSection);
                return Ok(CourseSectionDto);
            }
        }

        [HttpPost(Name = "createCourseSection")]
        public IActionResult CreateCourseSection([FromBody] CourseSectionForCreationDto CourseSection)
        {
            if (CourseSection == null)
            {
                _logger.LogError("CourseSection ForCreationDto object sent from client is null.");
                return BadRequest("CourseSection ForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseSectionForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var CourseSectionEntity = _mapper.Map<CourseSection>(CourseSection);

            _repository.CourseSection.CreateCourseSection(CourseSectionEntity);
            _repository.Save();

            var CourseSectionToReturn = _mapper.Map<CourseSectionDto>(CourseSectionEntity);

            return CreatedAtRoute("getCourseSectionById", new { id = CourseSectionToReturn.Id }, CourseSectionToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourseSection(Guid id, [FromBody] CourseSectionForUpdateDto CourseSection)
        {
            if (CourseSection == null)
            {
                _logger.LogError("CourseSectionForUpdateDto object sent from client is null.");
                return BadRequest("CourseSectionForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseSectionForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var CourseSectionEntity = _repository.CourseSection.GetCourseSection(id, trackChanges: true);
            if (CourseSectionEntity == null)
            {
                _logger.LogInfo($"CourseSection with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(CourseSection, CourseSectionEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourseSection(Guid id)
        {
            var CourseSection = _repository.CourseSection.GetCourseSection(id, trackChanges: false);
            if (CourseSection == null)
            {
                _logger.LogInfo($"Organiation with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.CourseSection.DeleteCourseSection(CourseSection);
            _repository.Save();

            return NoContent();
        }
    }
}