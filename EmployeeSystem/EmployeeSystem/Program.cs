

using EmployeeSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("EmployeeDb")
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
