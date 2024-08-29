using AutoMapper;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;

namespace Microservice.Book.Api.MediatR.AddBook;

public class AddBookCommandHandler(IBookRepository bookRepository,
                                   IMapper mapper) : IRequestHandler<AddBookRequest, AddBookResponse>
{

    public async Task<AddBookResponse> Handle(AddBookRequest addBookRequest, CancellationToken cancellationToken)
    {
        var book = mapper.Map<Api.Domain.Book>(addBookRequest);
        await bookRepository.AddAsync(book);

        return new AddBookResponse(book.Id);
    }
}