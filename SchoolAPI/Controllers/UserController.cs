using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
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

        [HttpGet(Name = "getAllUsers")]
        public IActionResult GetUsers()
        {
            var Users = _repository.User.GetAllUsers(trackChanges: false);

            var UserDto = _mapper.Map<IEnumerable<UserDto>>(Users);
            //uncomment the code below to test the global exception handling
            //throw new Exception("Exception");
            return Ok(UserDto);
        }

        [HttpGet("{id}", Name = "getUserById")]
        public IActionResult GetUser(Guid id)
        {
            var User = _repository.User.GetUser(id, trackChanges: false); if (User == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var UserDto = _mapper.Map<UserDto>(User);
                return Ok(UserDto);
            }
        }

        [HttpPost(Name = "createUser")]
        public IActionResult CreateUser([FromBody] UserForCreationDto User)
        {
            if (User == null)
            {
                _logger.LogError("User ForCreationDto object sent from client is null.");
                return BadRequest("User ForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the UserForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var UserEntity = _mapper.Map<User>(User);

            _repository.User.CreateUser(UserEntity);
            _repository.Save();

            var UserToReturn = _mapper.Map<UserDto>(UserEntity);

            return CreatedAtRoute("getUserById", new { id = UserToReturn.Id }, UserToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserForUpdateDto User)
        {
            if (User == null)
            {
                _logger.LogError("UserForUpdateDto object sent from client is null.");
                return BadRequest("UserForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the UserForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var UserEntity = _repository.User.GetUser(id, trackChanges: true);
            if (UserEntity == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(User, UserEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var User = _repository.User.GetUser(id, trackChanges: false);
            if (User == null)
            {
                _logger.LogInfo($"Organiation with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.User.DeleteUser(User);
            _repository.Save();

            return NoContent();
        }
    }
}