using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.EmployeeData;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmoloyee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"Employee with Id : {id} was not found");
        }
        [HttpPost]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmoloyee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme+"://"+HttpContext.Request.Host + HttpContext.Request.Path +"/" + employee.Id, employee);

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if(employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with id : {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EdditEmployee(Guid id ,Employee employee)
        {
            var existingemployee = _employeeData.GetEmployee(id);
            if (existingemployee != null)
            {
                employee.Id = existingemployee.Id;
                _employeeData.EdditEmployee(employee);
            }
            return Ok(employee);
        }
    }
}