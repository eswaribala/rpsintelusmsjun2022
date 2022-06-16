using ClaimAPI.Services;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Steeltoe.Discovery.Client;
var builder = WebApplication.CreateBuilder(args);
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: true)
    .Build();

// Add services to the container.
builder.Services.AddScoped<IInvokeService, InvokeService>();
builder.Services.AddHttpClient<IInvokeService, InvokeService>(options =>
{
    options.BaseAddress = new Uri("https://data.nasdaq.com/api/v3/datasets/OPEC/ORB.json");
}).AddPolicyHandler(InvokeService.GetCircuitBreakerPolicy())
.AddPolicyHandler(InvokeService.GetRetryPolicy());
builder.Services.AddControllers();
builder.Services.AddDiscoveryClient(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()

    .WriteTo.Debug()
    .WriteTo.Console()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new
        Uri(configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        IndexFormat = $"IntelOrderIndex-{DateTime.UtcNow:yyyy-MM}"
    })
    .Enrich.WithProperty("Environment", environment)
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();

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
