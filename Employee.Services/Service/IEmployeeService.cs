using Microsoft.AspNetCore.Mvc;
using Employee.Repository.Models;
namespace Employee.Service.Service
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeInfo> Get();

        // EmployeeInfo GetById(int id);
        int Create(EmployeeInfo employee);
        void Update(int id, EmployeeInfo employee);
        void Delete(int id);
    }
}
