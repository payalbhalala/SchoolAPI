using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Controllers
{
    [Route("api/v1/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var Users = _repository.User.GetAllUsers(trackChanges: false);
                return Ok(Users);
                /*var UserDto = _mapper.Map<IEnumerable<UserDto>>(Users);
                return Ok(UserDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetUsers)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetUsery(Guid id)
        {
            try
            {
                var User = _repository.User.GetUser(id, trackChanges: false); if (User == null)
                {
                    _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var userDto = _mapper.Map<UserDto>(User);
                    return Ok(userDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetUsers)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
