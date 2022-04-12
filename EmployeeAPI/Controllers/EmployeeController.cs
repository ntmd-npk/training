using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Context;
using Service.Service;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IBaseService<Employee> _employeeService;
        public EmployeeController(IBaseService<Employee> employeeService)
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
        public ActionResult<int> PostEmployee(Employee employee)
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
        public ActionResult UpdateEmployee(int id, Employee employee)
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

    }
}