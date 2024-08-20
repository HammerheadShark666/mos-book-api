using Microservice.Book.Api.Endpoints;
using Microservice.Book.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.ConfigureDatabaseContext(builder.Configuration);
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

Endpoints.ConfigureRoutes(app, builder.Configuration);

app.Run();