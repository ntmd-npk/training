using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Employee.Repository.Models;

namespace Employee.Repository.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Models.EmployeeInfo> EmployeeList { get; set; } = null!;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
       .UseInMemoryDatabase(databaseName: "Test")
       .Options;

            using (var context = new EmployeeContext(options))
            {

                context.EmployeeList.Add(new EmployeeInfo { Id = 0, Name = "Pham Lua", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362" });
                context.EmployeeList.Add(new EmployeeInfo { Id = 1, Name = "Hoang Van Thai", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362" });
                context.EmployeeList.Add(new EmployeeInfo { Id = 2, Name = "Huyen Nguyen", Birth = "2002-02-12", Address = "103 Nguyen Huy Tu", Phone = "0845162362" });

                context.SaveChanges();
            }

        }
    }


}

