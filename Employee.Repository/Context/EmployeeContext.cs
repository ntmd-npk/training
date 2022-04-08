using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Employee.Repository.Models;

namespace Employee.Repository.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Models.EmployeeInfo> EmployeeList { get; set; } = null!;


        public void InitData()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>().UseInMemoryDatabase(databaseName: "EmployeeList").Options;

            using (var context = new EmployeeContext(options))
            {

                context.EmployeeList.Add(new EmployeeInfo { Id = 1, Name = "Pham Lua", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362" });
                context.EmployeeList.Add(new EmployeeInfo { Id = 2, Name = "Hoang Van Thai", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362" });
                context.EmployeeList.Add(new EmployeeInfo { Id = 3, Name = "Huyen Nguyen", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362" });

                context.SaveChanges();
            }
        }
    }
}

