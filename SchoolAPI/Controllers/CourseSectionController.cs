using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Controllers
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

        [HttpGet]
        public IActionResult GetCourseSections()
        {
            try
            {
                var CourseSections = _repository.CourseSection.GetAllCourseSections(trackChanges: false);
                return Ok(CourseSections);
                /*var CourseSectionDto = _mapper.Map<IEnumerable<CourseSectionDto>>(CourseSections);
                return Ok(CourseSectionDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourseSections)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCourseSection(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourseSections)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
