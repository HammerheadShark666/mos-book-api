using AutoMapper;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;

namespace Microservice.Book.Api.MediatR.AddBook;

public class AddBookCommandHandler(IBookRepository bookRepository,
                                      IMapper mapper) : IRequestHandler<AddBookRequest, AddBookResponse>
{
    private IBookRepository _bookRepository { get; set; } = bookRepository;
    private IMapper _mapper { get; set; } = mapper;

    public async Task<AddBookResponse> Handle(AddBookRequest addBookRequest, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Api.Domain.Book>(addBookRequest); 
        await _bookRepository.AddAsync(book); 

        return new AddBookResponse(book.Id);
    }
} 