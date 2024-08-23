using AutoMapper;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;

namespace Microservice.Book.Api.MediatR.GetBook;

public class GetBookQueryHandler(IBookRepository bookRepository,
                                 ILogger<GetBookQueryHandler> logger,
                                 IMapper mapper) : IRequestHandler<GetBookRequest, GetBookResponse>
{
    private IBookRepository _bookRepository { get; set; } = bookRepository;
    private IMapper _mapper { get; set; } = mapper;
    private ILogger<GetBookQueryHandler> _logger { get; set; } = logger;

    public async Task<GetBookResponse> Handle(GetBookRequest getBookRequest, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.ByIdAsync(getBookRequest.Id);
        if (book == null)
        {
            _logger.LogError($"Book not found - {getBookRequest.Id}");
            throw new NotFoundException("Book not found.");
        }

        return _mapper.Map<GetBookResponse>(book);
    }
}