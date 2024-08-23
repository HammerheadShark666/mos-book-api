using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;

namespace Microservice.Book.Api.MediatR.DeleteBook;

public class DeleteBookCommandHandler(IBookRepository bookRepository,
                                      ILogger<DeleteBookCommandHandler> logger) : IRequestHandler<DeleteBookRequest, Unit>
{
    private IBookRepository _bookRepository { get; set; } = bookRepository;
    private ILogger<DeleteBookCommandHandler> _logger { get; set; } = logger;

    public async Task<Unit> Handle(DeleteBookRequest deleteBookRequest, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.ByIdAsync(deleteBookRequest.Id);
        if (book == null)
        {
            _logger.LogError($"Book not found - {deleteBookRequest.Id}");
            throw new NotFoundException("Book not found.");
        }

        await _bookRepository.Delete(book);
        return Unit.Value;
    }
}