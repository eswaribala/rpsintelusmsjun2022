using Microsoft.EntityFrameworkCore;
using VehicleAPI.Contexts;
using VehicleAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddDbContext<InsuranceContext>(options => 
options.UseSqlServer(configuration.
GetConnectionString("Insurance_Conn_String")));
//DI--Singleton,Scoped,Transient
builder.Services.AddScoped<IVehicleRepo, VehicleRepo>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
