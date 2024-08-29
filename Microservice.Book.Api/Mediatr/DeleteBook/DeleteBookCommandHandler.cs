using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;

namespace Microservice.Book.Api.MediatR.DeleteBook;

public class DeleteBookCommandHandler(IBookRepository bookRepository,
                                      ILogger<DeleteBookCommandHandler> logger) : IRequestHandler<DeleteBookRequest, Unit>
{
    public async Task<Unit> Handle(DeleteBookRequest deleteBookRequest, CancellationToken cancellationToken)
    {
        var book = await bookRepository.ByIdAsync(deleteBookRequest.Id);
        if (book == null)
        {
            logger.LogError("Book not found - {deleteBookRequest.Id}", deleteBookRequest.Id);
            throw new NotFoundException("Book not found.");
        }

        await bookRepository.Delete(book);
        return Unit.Value;
    }
}