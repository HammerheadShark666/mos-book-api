using Asp.Versioning;
using MediatR;
using Microservice.Book.Api.MediatR.AddBook;
using Microservice.Book.Api.MediatR.DeleteBook;
using Microservice.Book.Api.MediatR.GetBook;
using Microservice.Book.Api.MediatR.SearchBookTitle;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Book.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/book")]
[ApiController]
public class BookController(IMediator mediator, ILogger<BookController> logger) : BaseController
{
    private ILogger<BookController> _logger { get; set; } = logger;    
    private IMediator _mediator { get; set; } = mediator;
  
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IResult> GetById(Guid id)
    { 
        var result = await _mediator.Send(new GetBookRequest(id));
        return result == null ? Results.NotFound() : Results.Ok(result); 
    }


    [HttpGet("title/{criteria}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IResult> GetByTitle(string criteria)
    {
        var result = await _mediator.Send(new SearchBookTitleRequest(criteria));
        return result == null ? Results.NotFound() : Results.Ok(result);
    }

    [HttpPost("add")]
    public async Task<IResult> Update([FromBody] AddBookRequest addBookRequest)
    {  
        var result = await _mediator.Send(addBookRequest);
        return result == null ? Results.NotFound() : Results.Ok(result);
    }

    [HttpPut("update")]
    public async Task<IResult> Update([FromBody] UpdateBookRequest updateBookRequest)
    { 
        var result = await _mediator.Send(updateBookRequest);
        return result == null ? Results.NotFound() : Results.Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IResult> Delete([FromBody] DeleteBookRequest deleteBookRequest)
    {
        await _mediator.Send(deleteBookRequest);
        return Results.Ok();
    }
}