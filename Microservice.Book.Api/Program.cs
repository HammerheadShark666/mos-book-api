using Microservice.Book.Api.Endpoints;
using Microservice.Book.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.ConfigureGrpc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.ConfigureExceptionHandling();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureDI();
builder.Services.ConfigureSqlServer(builder.Configuration, environment);
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureJwt();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureApiVersioning();

var app = builder.Build();

app.ConfigureGprc();
app.ConfigureSwagger();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.ConfigureMiddleware();

Endpoints.ConfigureRoutes(app);

app.Run();