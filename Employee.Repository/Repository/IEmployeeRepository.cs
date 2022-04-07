using Employee.Repository.Models;

namespace Employee.Repository.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeInfo> Get();
        //public int GetEmployeeById(int id);
        //public int Create(EmployeeInfo employee);
        //public void Update(int id, EmployeeInfo employee);
        void Delete(int id);
    }
}
