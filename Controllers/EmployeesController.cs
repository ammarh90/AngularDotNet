using AngularDotNet.Data.Models;
using AngularDotNet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeesService _employeesService { get; set; }


        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<Employee> employees = _employeesService.GetAllEmployees();

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = _employeesService.getEmployeeById(id);

            if (employee == null)
            {
                string notFoundString = String.Format("Employee with id:{0} not found", id);
                return NotFound(notFoundString);
            }
            return Ok(employee);
        }


        [HttpGet]
        [Route("{active:bool}")]
        public IActionResult GetEmployeesByActivity(bool active)
        {

            return Ok(_employeesService.getEmployeesByActivity(active));
        }


        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if(employee.Id == null)
            {
                return BadRequest("EmployeeId is mandatory");
            }
            if (_employeesService.getEmployeeById(employee.Id)!=null)
            {
                return BadRequest("Employee already exists");
            }
            Employee addedEmployee = _employeesService.AddEmployee(employee);
            return Ok(addedEmployee);
        }


        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (employee.Id == null)
            {
                return BadRequest("EmployeeId is mandatory");
            }
            Employee existingEmployee= _employeesService.getEmployeeById(employee.Id);
            if (existingEmployee == null)
            {
                return BadRequest("Employee not found");
            }
            Employee addedEmployee = _employeesService.UpdateEmployee(employee);
            return Ok(addedEmployee);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee existingEmployee = _employeesService.getEmployeeById(id);
            if (existingEmployee == null)
            {
                return BadRequest("Employee not found");
            }
            _employeesService.DeleteEmployee(id);

            return Ok();
        }
    }
}
