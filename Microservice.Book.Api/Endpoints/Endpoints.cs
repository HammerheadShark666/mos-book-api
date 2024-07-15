using Asp.Versioning;
using MediatR;
using Microservice.Book.Api.Extensions;
using Microservice.Book.Api.Helpers.Exceptions;
using Microservice.Book.Api.MediatR.AddBook;
using Microservice.Book.Api.MediatR.DeleteBook;
using Microservice.Book.Api.MediatR.GetBook;
using Microservice.Book.Api.MediatR.SearchBookTitle;
using Microservice.Book.Api.MediatR.UpdateBook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Net;

namespace Microservice.Book.Api.Endpoints;

public static class Endpoints
{
    public static void ConfigureRoutes(this WebApplication app, ConfigurationManager configuration)
    {
        var bookGroup = app.MapGroup("api/v{version:apiVersion}/book").WithTags("book");

        bookGroup.MapGet("/{id}", async ([FromRoute] Guid id, [FromServices] IMediator mediator) => {
            var getBookResponse = await mediator.Send(new GetBookRequest(id));
            return Results.Ok(getBookResponse);
        }) 
        .Produces<GetBookResponse>((int)HttpStatusCode.OK)
        .Produces<BadRequestException>((int)HttpStatusCode.BadRequest)
        .WithName("GetBook")
        .WithApiVersionSet(app.GetApiVersionSet())
        .MapToApiVersion(new ApiVersion(1, 0))
        .RequireAuthorization()
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Get a book based on id.",
            Description = "Gets a book based on its id.",
            Tags = new List<OpenApiTag> { new() { Name = "Microservice Order System - Books" } }
        });

        bookGroup.MapGet("/title/{criteria}", async ([FromRoute] string criteria, [FromServices] IMediator mediator) => {
            var searchBookTitleResponse = await mediator.Send(new SearchBookTitleRequest(criteria));
            return Results.Ok(searchBookTitleResponse);
        })
        .Accepts<SearchBookTitleRequest>("application/json")
        .Produces<SearchBookTitleResponse>((int)HttpStatusCode.OK)
        .Produces<BadRequestException>((int)HttpStatusCode.BadRequest)
        .WithName("SearchBookTitle")
        .WithApiVersionSet(app.GetApiVersionSet())
        .MapToApiVersion(new ApiVersion(1, 0))
        .RequireAuthorization()
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Search for books based on title.",
            Description = "Gets books based on title.",
            Tags = new List<OpenApiTag> { new() { Name = "Microservice Order System - Books" } }
        });

        bookGroup.MapPost("/add", async (AddBookRequest addBookRequest, IMediator mediator) => {
            var addBookResponse = await mediator.Send(addBookRequest);
            return Results.Ok(addBookResponse);
        })
        .Accepts<AddBookRequest>("application/json")
        .Produces<AddBookResponse>((int)HttpStatusCode.OK)
        .Produces<BadRequestException>((int)HttpStatusCode.BadRequest)
        .WithName("AddBook")
        .WithApiVersionSet(app.GetApiVersionSet())
        .MapToApiVersion(new ApiVersion(1, 0))
        .RequireAuthorization()
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Add a book.",
            Description = "Adds a book.",
            Tags = new List<OpenApiTag> { new() { Name = "Microservice Order System - Books" } }
        });

        bookGroup.MapPut("/update", async (UpdateBookRequest updateBookRequest, IMediator mediator) => {
            var updateBookResponse = await mediator.Send(updateBookRequest);
            return Results.Ok(updateBookResponse);
        })
        .Accepts<UpdateBookRequest>("application/json")
        .Produces<UpdateBookResponse>((int)HttpStatusCode.OK)
        .Produces<BadRequestException>((int)HttpStatusCode.BadRequest)
        .WithName("UpdateBook")
        .WithApiVersionSet(app.GetApiVersionSet())
        .MapToApiVersion(new ApiVersion(1, 0))
        .RequireAuthorization()
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Update a book.",
            Description = "Updates a book.",
            Tags = new List<OpenApiTag> { new() { Name = "Microservice Order System - Books" } }
        });

        bookGroup.MapDelete("/{id}", async ([FromRoute] Guid id, [FromServices] IMediator mediator) => {
            var deleteBookResponse = await mediator.Send(new DeleteBookRequest(id));
            return Results.Ok(deleteBookResponse);
        })
        .Accepts<DeleteBookRequest>("application/json")
        .Produces((int)HttpStatusCode.OK)
        .Produces<BadRequestException>((int)HttpStatusCode.BadRequest)
        .WithName("DeleteBook")
        .WithApiVersionSet(app.GetApiVersionSet())
        .MapToApiVersion(new ApiVersion(1, 0))
        .RequireAuthorization()
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Delete a book.",
            Description = "Deletes a book.",
            Tags = new List<OpenApiTag> { new() { Name = "Microservice Order System - Books" } }
        });
    }
}