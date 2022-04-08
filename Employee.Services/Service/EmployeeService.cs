using Employee.Repository.Models;
using Employee.Repository;
using Microsoft.AspNetCore.Mvc;
using Employee.Repository.Repository;

namespace Employee.Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<EmployeeInfo> Get()
        {
            return _employeeRepository.Get();
        }

        public int Create(EmployeeInfo employee)
        {
            return _employeeRepository.Create(employee);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }


        // public EmployeeInfo GetById(int id)
        // {
        //     _employeeRepository.GetById(id);
        // }

        public void Update(int id, EmployeeInfo employee)
        {
            _employeeRepository.Update(id, employee);
        }
    }
}
