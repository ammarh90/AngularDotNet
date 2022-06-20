using AngularDotNet.Data.Models;
using AngularDotNet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private EmployeesService _employeesService { get; set; }


        public DepartmentController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }



        [HttpGet]
        [Route("{departmentId:int}/employees/{isActive:bool?}")]
        public IActionResult GetEmployeesByDepartment(int departmentId, bool isActive = true)
        {

            List<Employee> employees = _employeesService.getEmployeesByDepartment(departmentId, isActive);

            return Ok(employees);
        }

    }
}
