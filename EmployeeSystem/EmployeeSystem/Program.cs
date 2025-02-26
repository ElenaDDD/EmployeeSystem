

using EmployeeSystem.Data;
using EmployeeSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;


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

//add the Emploee repository for DI
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
        c.RoutePrefix = string.Empty;
    });

}
app.MapControllers();

app.UseCors("MyCors");

app.Run();
