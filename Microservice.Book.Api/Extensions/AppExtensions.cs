using Asp.Versioning;
using Asp.Versioning.Builder;
using Microservice.Book.Api.Grpc;
using Microservice.Book.Api.Middleware;

namespace Microservice.Book.Api.Extensions;

public static class AppExtensions
{
    public static void ConfigureGprc(this WebApplication webApplication)
    {
        webApplication.MapGrpcService<BookService>();
        webApplication.MapGrpcReflectionService();
    }

    public static void ConfigureSwagger(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI(options =>
            {
                options.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);

                var descriptions = webApplication.DescribeApiVersions();

                // Build a swagger endpoint for each discovered API version
                foreach (var description in descriptions)
                {
                    var url = $"/swagger/{description.GroupName}/swagger.json";
                    var name = description.GroupName.ToUpperInvariant();
                    options.SwaggerEndpoint(url, name);
                }
            });
        }
    }

    public static ApiVersionSet GetApiVersionSet(this WebApplication webApplication)
    {
        return webApplication.NewApiVersionSet()
                  .HasApiVersion(new ApiVersion(1))
                  .ReportApiVersions()
                  .Build();
    }

    public static void ConfigureMiddleware(this WebApplication webApplication)
    {
        if (!webApplication.Environment.IsDevelopment())
        {
            webApplication.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
