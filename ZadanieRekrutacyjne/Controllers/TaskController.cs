using Microsoft.AspNetCore.Mvc;
using EmployersAndTasks.Models;
using EmployersAndTasks.Services;

namespace EmployersAndTasks.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService service;

        public TaskController(ITaskService service)
        {
            this.service = service;
        }
        [HttpPost]
        public ActionResult Post([FromBody] AddTaskDto dto)
        {
            var id = service.Post(dto);
            return Created("", null);
        }
        [HttpGet("{employeeId}")]
        public ActionResult GetAll([FromRoute] int employeeId)
        {
            var result = service.GetAll(employeeId);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] string status, [FromRoute] int id)
        {
            service.Put(status, id);
            return Ok();
        }
    }
}
