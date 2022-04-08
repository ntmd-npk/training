using Microsoft.AspNetCore.Mvc;
using Repository.Models;
namespace Service.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> Get();

        // EmployeeInfo GetById(int id);
        int Create(Employee employee);
        void Update(int id, Employee employee);
        void Delete(int id);
    }
}
