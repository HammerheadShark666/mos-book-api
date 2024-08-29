using AutoMapper;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;

namespace Microservice.Book.Api.MediatR.UpdateBook;

public class UpdateBookCommandHandler(IBookRepository bookRepository,
                                      ILogger<UpdateBookCommandHandler> logger,
                                      IMapper mapper) : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
{
    public async Task<UpdateBookResponse> Handle(UpdateBookRequest updateBookRequest, CancellationToken cancellationToken)
    {
        var existingBook = await bookRepository.ByIdAsync(updateBookRequest.Id);
        if (existingBook == null)
        {
            logger.LogError("Book not found - {updateBookRequest.Id}", updateBookRequest.Id);
            throw new NotFoundException("Book not found.");
        }

        existingBook = mapper.Map(updateBookRequest, existingBook);

        await bookRepository.UpdateAsync(existingBook);

        return new UpdateBookResponse("Book Updated.");
    }
}