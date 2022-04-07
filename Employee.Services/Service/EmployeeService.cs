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
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeInfo> Get()
        {
            return _employeeRepository.Get();
        }
    }
}
