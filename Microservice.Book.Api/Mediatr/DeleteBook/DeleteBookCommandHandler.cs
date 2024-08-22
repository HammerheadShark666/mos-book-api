using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;

namespace Microservice.Book.Api.MediatR.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookRequest, Unit>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.ByIdAsync(request.Id);
        if (book == null)
            throw new NotFoundException("Book not found.");

        await _bookRepository.Delete(book);
        return Unit.Value;
    }
}