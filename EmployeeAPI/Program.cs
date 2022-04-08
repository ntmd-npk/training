using Microsoft.EntityFrameworkCore;
using Employee.Repository.Context;
using Employee.Service.Service;
using Employee.Repository.Repository;
using Employee.Repository.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<EmployeeContext>(opt =>
   opt.UseInMemoryDatabase("EmployeeList"));

var serviceProvider = builder.Services.BuildServiceProvider();
var dbContext = serviceProvider.GetService<EmployeeContext>();
dbContext.InitData();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("corsapp");

app.MapControllers();

app.Run();
