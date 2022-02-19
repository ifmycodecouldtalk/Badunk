using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badunk.Controllers
{
    [Route("api/users/{userId}/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public TasksController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTasksForUser(Guid userId)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
            return NotFound();
            }
            var tasksFromDb = _repository.Task.GetTasks(userId,
           trackChanges: false);
            return Ok(tasksFromDb);
        }

        [HttpPost]
        public IActionResult CreateTaskForUser(Guid userId, [FromBody] TaskForCreationDto task)
        {
            if (task == null)
            {
                return BadRequest("EmployeeForCreationDto object is null");
            }
            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                return NotFound();
            }
            var taskEntity = _mapper.Map<Entities.Models.Task>(task);

            _repository.Task.CreateTaskForUser(userId, taskEntity);
            _repository.Save();
            var employeeToReturn = _mapper.Map<TaskDto>(taskEntity);
            return CreatedAtRoute("GetEmployeeForCompany", new
            {
                userId,
                id =
                employeeToReturn.Id
            }, employeeToReturn);
        }
    }
}
