using AutoMapper;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;

namespace Microservice.Book.Api.MediatR.GetBook;

public class GetBookQueryHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<GetBookRequest, GetBookResponse>
{
    private IBookRepository _bookRepository { get; set; } = bookRepository ;
    private IMapper _mapper { get; set; } = mapper;
     
    public async Task<GetBookResponse> Handle(GetBookRequest request, CancellationToken cancellationToken)
    {  
        var book = await _bookRepository.ByIdAsync(request.Id);
        if (book == null)
            throw new NotFoundException($"Book not found for id - {request.Id}");

        return _mapper.Map<GetBookResponse>(book); 
    }
}