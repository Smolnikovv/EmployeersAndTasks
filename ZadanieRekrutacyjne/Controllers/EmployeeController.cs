using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmployersAndTasks.Models;
using EmployersAndTasks.Services;

namespace EmployersAndTasks.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }
        [HttpPost]
        public ActionResult Post([FromBody] AddEmployeeDto dto)
        {
            var id = service.Post(dto);
            return Created($"/api/employee/", null);
        }
        [HttpGet]
        public ActionResult<List<EmployeeDto>> GetAll()
        {
            var result = service.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetById([FromRoute] int id)
        {
            var result = service.GetById(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteById([FromRoute] int id)
        {
            service.DeleteById(id);
            return Ok();
        }
    }
}
