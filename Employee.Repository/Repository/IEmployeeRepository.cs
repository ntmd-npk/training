using Repository.Models;

namespace Repository.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        // EmployeeInfo GetById(int id);
        int Create(Employee employee);
        void Update(int id, Models.Employee employee);
        void Delete(int id);
    }
}
