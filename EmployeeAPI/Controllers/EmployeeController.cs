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
            try
            {
                var employees = _employeeService.Get();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST
        [HttpPost]
        public ActionResult<int> PostEmployee(EmployeeInfo employee)
        {
            try
            {
                var id = _employeeService.Create(employee);
                return Ok(id);
            }
            catch
            {
                return NotFound();
            }
        }


        // DELETE
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeService.Delete(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }


        // PUT
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeInfo employee)
        {
            try
            {
                _employeeService.Update(id, employee);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }


        // GET
        // [HttpGet("{id}")]
        // public ActionResult GetEmployee(int id)
        // {
        //     var employee = _employeeService.GetById(id);

        //     return Ok(employee);
        // }
    }
}
