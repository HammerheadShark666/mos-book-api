using AutoMapper;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;

namespace Microservice.Book.Api.MediatR.GetBook;

public class GetBookQueryHandler(IBookRepository bookRepository,
                                 ILogger<GetBookQueryHandler> logger,
                                 IMapper mapper) : IRequestHandler<GetBookRequest, GetBookResponse>
{
    public async Task<GetBookResponse> Handle(GetBookRequest getBookRequest, CancellationToken cancellationToken)
    {
        var book = await bookRepository.ByIdAsync(getBookRequest.Id);
        if (book == null)
        {
            logger.LogError("Book not found - {getBookRequest.Id}", getBookRequest.Id);
            throw new NotFoundException("Book not found.");
        }

        return mapper.Map<GetBookResponse>(book);
    }
}