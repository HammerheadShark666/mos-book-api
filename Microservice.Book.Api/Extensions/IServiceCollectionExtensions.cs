using Asp.Versioning;
using FluentValidation;
using MediatR;
using Microservice.Book.Api.Data.Context;
using Microservice.Book.Api.Data.Repository;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers;
using Microservice.Book.Api.Helpers.Interfaces;
using Microservice.Book.Api.Helpers.Swagger;
using Microservice.Book.Api.MediatR.AddBook;
using Microservice.Book.Api.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Microservice.Book.Api.Extensions;

public static class IServiceCollectionExtensions
{
    public static void ConfigureExceptionHandling(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlingMiddleware>();
    }

    public static void ConfigureJwt(this IServiceCollection services)
    {
        services.AddJwtAuthentication();
    }

    public static void ConfigureDI(this IServiceCollection services)
    {
        services.AddScoped<IBookHelper, BookHelper>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddMemoryCache();
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(AddBookMapper)));
    }

    public static void ConfigureDatabaseContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContextFactory<BookDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(Helpers.Constants.DatabaseConnectionString),
            options => options.EnableRetryOnFailure()));
    }

    public static void ConfigureMediatr(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<AddBookValidator>();
        services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
    }

    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<SwaggerDefaultValues>();
            options.SupportNonNullableReferenceTypes();
        });
    }

    public static void ConfigureGrpc(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddGrpcReflection();
        services.AddGrpc().AddJsonTranscoding();
    }
}