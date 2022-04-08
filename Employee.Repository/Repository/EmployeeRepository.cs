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

        public IEnumerable<EmployeeInfo> Get()
        {
            return _context.EmployeeList;
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

        public int Create(EmployeeInfo employee)
        {
            if (_context.EmployeeList.Count() == 0)
            {
                employee.Id = 1;
            }
            else
            {
                var maxId = _context.EmployeeList.Max(_ => _.Id);
                employee.Id = ++maxId;
            }

            _context.EmployeeList.Add(employee);
            _context.SaveChanges();

            return employee.Id;
        }



        // public EmployeeInfo GetById(int id)
        // {
        //     var findEmployee = _context.EmployeeList.FirstOrDefault((e) => e.Id == id);
        //     if (findEmployee is null)
        //     {
        //         throw new ArgumentException("Could not find employee");
        //     }
        //     return 1;
        // }

        public void Update(int id, EmployeeInfo employee)
        {

            var editEmployee = _context.EmployeeList.FirstOrDefault((e) => e.Id == id);
            if (editEmployee is null)
            {
                throw new ArgumentException("Could not find employee");
            }

            if (employee.Name != null) editEmployee.Name = employee.Name;
            if (employee.Birth != null) editEmployee.Birth = employee.Birth;
            if (employee.Address != null) editEmployee.Address = employee.Address;
            if (employee.Phone != null) editEmployee.Phone = employee.Phone;

            _context.SaveChanges();
        }
    }
}