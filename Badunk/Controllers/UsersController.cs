using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badunk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public UsersController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _repository.User.GetAllUsers(trackChanges: false);
                var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

                return Ok(usersDto);
            }
            catch (Exception)
            {
            return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name = "UserById")]
        public IActionResult GetUser(Guid id)
        {
            var users = _repository.User.GetUser(id, trackChanges: false);
            if (users == null)
            {
                return NotFound();
            }
            else
            {
                var usersDto = _mapper.Map<UserDto>(users);
                return Ok(usersDto);
            }
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserForCreationDto user)
        {
            if (user == null)
            {
                return BadRequest("UserForCreationDto object is null");
            }
            var userEntity = _mapper.Map<UserInfo>(user);
            _repository.User.CreateUser(userEntity);
            _repository.Save();
            var userToReturn = _mapper.Map<UserDto>(userEntity);
            return CreatedAtRoute("UserById", new { id = userToReturn.Id },
            userToReturn);
        }


    }
}
