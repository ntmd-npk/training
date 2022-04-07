using Microsoft.AspNetCore.Mvc;
using Employee.Repository.Models;
namespace Employee.Service.Service
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeInfo> Get();

        //ActionResult GetEmployeeById(int id);
        //ActionResult Create(EmployeeInfo employee);
        //ActionResult Update(int id, EmployeeInfo employee);
        void Delete(int id);
    }
}
