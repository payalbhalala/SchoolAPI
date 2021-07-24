using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [Route("api/v1/SectionEnrollments")]
    [ApiController]
    public class SectionEnrollmentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SectionEnrollmentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "getAllSectionEnrollments")]
        public IActionResult GetSectionEnrollments()
        {
            var SectionEnrollments = _repository.SectionEnrollment.GetAllSectionEnrollments(trackChanges: false);

            var SectionEnrollmentDto = _mapper.Map<IEnumerable<SectionEnrollmentDto>>(SectionEnrollments);
            //uncomment the code below to test the global exception handling
            //throw new Exception("Exception");
            return Ok(SectionEnrollmentDto);
        }

        [HttpGet("{id}", Name = "getSectionEnrollmentById")]
        public IActionResult GetSectionEnrollment(Guid id)
        {
            var SectionEnrollment = _repository.SectionEnrollment.GetSectionEnrollment(id, trackChanges: false); if (SectionEnrollment == null)
            {
                _logger.LogInfo($"SectionEnrollment with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var SectionEnrollmentDto = _mapper.Map<SectionEnrollmentDto>(SectionEnrollment);
                return Ok(SectionEnrollmentDto);
            }
        }

        [HttpPost(Name = "createSectionEnrollment")]
        public IActionResult CreateSectionEnrollment([FromBody] SectionEnrollmentForCreationDto SectionEnrollment)
        {
            if (SectionEnrollment == null)
            {
                _logger.LogError("SectionEnrollment ForCreationDto object sent from client is null.");
                return BadRequest("SectionEnrollment ForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SectionEnrollmentForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var SectionEnrollmentEntity = _mapper.Map<SectionEnrollment>(SectionEnrollment);

            _repository.SectionEnrollment.CreateSectionEnrollment(SectionEnrollmentEntity);
            _repository.Save();

            var SectionEnrollmentToReturn = _mapper.Map<SectionEnrollmentDto>(SectionEnrollmentEntity);

            return CreatedAtRoute("getSectionEnrollmentById", new { id = SectionEnrollmentToReturn.Id }, SectionEnrollmentToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSectionEnrollment(Guid id, [FromBody] SectionEnrollmentForUpdateDto SectionEnrollment)
        {
            if (SectionEnrollment == null)
            {
                _logger.LogError("SectionEnrollmentForUpdateDto object sent from client is null.");
                return BadRequest("SectionEnrollmentForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SectionEnrollmentForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var SectionEnrollmentEntity = _repository.SectionEnrollment.GetSectionEnrollment(id, trackChanges: true);
            if (SectionEnrollmentEntity == null)
            {
                _logger.LogInfo($"SectionEnrollment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(SectionEnrollment, SectionEnrollmentEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSectionEnrollment(Guid id)
        {
            var SectionEnrollment = _repository.SectionEnrollment.GetSectionEnrollment(id, trackChanges: false);
            if (SectionEnrollment == null)
            {
                _logger.LogInfo($"Organiation with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.SectionEnrollment.DeleteSectionEnrollment(SectionEnrollment);
            _repository.Save();

            return NoContent();
        }
    }
}