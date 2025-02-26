

using EmployeeSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("EmployeeDb")
);
builder.Services.AddCors(opions =>
   opions.AddPolicy("MyCors", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    })
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
