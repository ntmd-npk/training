using Employee.Repository.Models;

namespace Employee.Repository.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeInfo> Get();
        // EmployeeInfo GetById(int id);
        int Create(EmployeeInfo employee);
        void Update(int id, EmployeeInfo employee);
        void Delete(int id);
    }
}
