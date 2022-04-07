using Employee.Repository.Models;
using Employee.Repository.Context;

namespace Employee.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var deletedEmployee = _context.EmployeeList.FirstOrDefault(e => e.Id == id);

            if (deletedEmployee == null)
            {
                throw new ArgumentException("Not found employee");
            }

            _context.EmployeeList.Remove(deletedEmployee);
            _context.SaveChanges();
        }

        //public int Create(EmployeeInfo employee)
        //{
        //    var maxId = _context.Max(_ => _.Id);
        //    employee.Id = ++maxId;
        //    _context.Add(employee);
        //    _context.SaveChanges();
        //    return employee.Id;
        //}

        //public void Delete(int id)
        //{
        //    _context.SaveChanges();
        //}



        //public int GetEmployeeById(int id)
        //{
        //    _context.SaveChanges();
        //}

        //public void Update(int id, EmployeeInfo employee)
        //{
        //    _context.SaveChanges();
        //}

        public IEnumerable<EmployeeInfo> Get()
        {
            return _context.EmployeeList;
        }
    }
}


//public ActionResult GetEmployeeById(int id)
//{
//    var employee = _context.Find((_) => _.Id == id);

//    if (employee == null)
//        return NotFound();

//    return Ok(employee.Id);
//}

//public ActionResult Create(EmployeeInfo employee)
//{
//    var maxId = _context.Max(_ => _.Id);
//    employee.Id = ++maxId;
//    _context.Add(employee);

//    return Ok(employee.Id);
//}
//public ActionResult Update(int id, EmployeeInfo employee)
//{
//    var employee = _context.Find((_) => _.Id == id);

//    if (employee == null)
//        return BadRequest();

//    _context.Remove(employee);

//    return NoContent();
//}

//public ActionResult Delete(int id)
//{
//    var editEmployee = _context.First(_ => _.Id == id);

//    if (editEmployee == null)
//        return NotFound();

//    if (!string.IsNullOrEmpty(employee.Name))
//        editEmployee.Name = employee.Name;
//    if (!string.IsNullOrEmpty(employee.Birth))
//        editEmployee.Birth = employee.Birth;
//    if (!string.IsNullOrEmpty(employee.Address))
//        editEmployee.Address = employee.Address;
//    if (!string.IsNullOrEmpty(employee.Phone))
//        editEmployee.Phone = employee.Phone;

//    return NoContent();
//}