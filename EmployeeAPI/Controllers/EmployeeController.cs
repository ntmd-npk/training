using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<EmployeeItem> _context = new List<EmployeeItem> {
            new EmployeeItem{Id = 0,  Name  = "Pham Lua", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362"} ,
            new EmployeeItem{Id = 1, Name  = "Huyen Nguyen", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362"},
            new EmployeeItem{Id = 2,  Name  = "Diem Truong", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362"} ,
        };

        public EmployeeController()
        {
            //_context.Add(new EmployeeItem());
            //_context.Add(new EmployeeItem());
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult<List<EmployeeItem>> GetEmployeeItems() => Ok(_context);

        // GET
        [HttpGet("{id}")]
        public ActionResult GetEmployeeItem(int id)
        {
            EmployeeItem employee = _context.Find((item) => item.Id == id);

            if (employee == null)
                return NotFound();

            return Ok(employee.Id);
        }

        // POST
        [HttpPost]
        public ActionResult<int> PostEmployeeItem(EmployeeItem employee)
        {
            var maxId = _context.Max(_ => _.Id);
            employee.Id = ++maxId;
            _context.Add(employee);

            return Ok(employee.Id);
        }


        // DELETE
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployeeItem(int id)
        {
            EmployeeItem employee = _context.Find((item) => item.Id == id);

            if (employee == null)
                return BadRequest();

            _context.Remove(employee);

            return NoContent();
        }


        // PUT
        [HttpPut("{id}")]
        public ActionResult UpdateEmployeeItem(int id, EmployeeItem employee)
        {
            var editEmployee = _context.First(_ => _.Id == id);

            if (editEmployee == null) { return NotFound(); }
            if (!string.IsNullOrEmpty(employee.Name)) { editEmployee.Name = employee.Name; }
            if (!string.IsNullOrEmpty(employee.Birth)) { editEmployee.Birth = employee.Birth; }
            if (!string.IsNullOrEmpty(employee.Address)) { editEmployee.Address = employee.Address; }
            if (!string.IsNullOrEmpty(employee.Phone)) { editEmployee.Phone = employee.Phone; }
            return NoContent();
        }
    }
}
