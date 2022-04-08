using Repository.Models;
using Repository;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;

namespace Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _employeeRepository;
        //private readonly IGenericRepository<Employee> _employeeRepository;
        public EmployeeService(IRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.Get();
        }

        public int Create(Employee employee)
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

        public void Update(int id, Repository.Models.Employee employee)
        {
            _employeeRepository.Update(id, employee);
        }
    }
}
