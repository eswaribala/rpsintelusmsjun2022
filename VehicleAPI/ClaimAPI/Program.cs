using ClaimAPI.Services;
using Steeltoe.Discovery.Client;
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
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
