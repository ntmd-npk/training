using Microsoft.AspNetCore.Mvc;
using Employee.Repository.Models;
using Employee.Repository.Context;
using Employee.Service.Service;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult GetEmployees()
        {
            var employees = _employeeService.Get();

            return Ok(employees);
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult GetEmployee(int id)
        {
            return EmployeeService.GetEmployeeById();
        }

        // POST
        [HttpPost]
        public ActionResult<int> PostEmployee(EmployeeInfo employee)
        {
            return EmployeeService.Create(employee);
        }


        // DELETE
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            return EmployeeService.Delete(id);
        }


        // PUT
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeInfo employee)
        {
            return EmployeeService.Update(id, employee);
        }
    }
}
