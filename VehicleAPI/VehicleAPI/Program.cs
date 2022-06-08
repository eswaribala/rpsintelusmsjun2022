using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Extensions.Configuration.ConfigServer;
using VehicleAPI.Contexts;
using VehicleAPI.Models;
using VehicleAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddConfigServer();
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

Dictionary<String, Object> data = new VaultConfiguration(configuration)
    .GetDBCredentials().Result;
Console.WriteLine(data);
SqlConnectionStringBuilder providerCs = new SqlConnectionStringBuilder();
providerCs.InitialCatalog = data["dbname1"].ToString();
providerCs.UserID = data["username"].ToString();
providerCs.Password = data["password"].ToString();
//providerCs.DataSource = "DESKTOP-55AGI0I\\MSSQLEXPRESS2021";
providerCs.DataSource = configuration["servername"];

//providerCs.UserID = CryptoService2.Decrypt(ConfigurationManager.
//AppSettings["UserId"]);
providerCs.MultipleActiveResultSets = true;
providerCs.TrustServerCertificate = false;

builder.Services.AddDbContext<InsuranceContext>(o => 
o.UseSqlServer(providerCs.ToString()));





//builder.Services.AddDbContext<InsuranceContext>(options => 
//options.UseSqlServer(configuration.
//GetConnectionString("Insurance_Conn_String")));
//DI--Singleton,Scoped,Transient
builder.Services.AddScoped<IVehicleRepo, VehicleRepo>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddApiVersioning();
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
    x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
});
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
