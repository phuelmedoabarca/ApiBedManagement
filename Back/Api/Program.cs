using Api.Extensions;
using Application.Pacientes.Command.Create;
using Application.Pacientes.Command.Set;
using Application.Pacientes.Queries.GetList;
using Domain.Entities;
using Domain.Repositorio;
using Infraestructura;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddRepositories();
builder.Services.AddHandlers();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandler();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
