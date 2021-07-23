using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Controllers
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

        [HttpGet]
        public IActionResult GetSectionEnrollments()
        {
            try
            {
                var SectionEnrollments = _repository.SectionEnrollment.GetAllSectionEnrollments(trackChanges: false);
                return Ok(SectionEnrollments);
                /*var SectionEnrollmentDto = _mapper.Map<IEnumerable<SectionEnrollmentDto>>(SectionEnrollments);
                return Ok(SectionEnrollmentDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSectionEnrollments)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetSectionEnrollmenty(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSectionEnrollments)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
