using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Repository.Models;
namespace Repository.Context
{
    public class ManageContext : DbContext
    {
        public ManageContext(DbContextOptions<ManageContext> options) : base(options)
        {
        }

        public DbSet<Employee> EmployeeList { get; set; } = null!;
        public DbSet<Company> CompanyList { get; set; } = null!;


        public void InitData()
        {
            // Database name: Employee -> database contains multiple table or DbSet such as EmployeeList, CompanyList,...
            var employeeOptions = new DbContextOptionsBuilder<ManageContext>().UseInMemoryDatabase(databaseName: "Employee").Options;

            using (var context = new ManageContext(employeeOptions))
            {

                context.EmployeeList.Add(new Employee { Id = 1, Name = "Pham Lua", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362" });
                context.EmployeeList.Add(new Employee { Id = 2, Name = "Hoang Van Thai", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362" });
                context.EmployeeList.Add(new Employee { Id = 3, Name = "Huyen Nguyen", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362" });

                context.CompanyList.Add(new Company { Id = 1, Name = "Company A", Location = "123 Nguyen Hoang Dieu" });
                context.CompanyList.Add(new Company { Id = 2, Name = "Company B", Location = "123 Nguyen Hoang Dieu" });
                context.CompanyList.Add(new Company { Id = 3, Name = "Company C", Location = "123 Nguyen Hoang Dieu" });

                context.SaveChanges();
            }
        }
    }
}
