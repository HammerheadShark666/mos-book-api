using AutoMapper;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;

namespace Microservice.Book.Api.MediatR.UpdateBook;

public class UpdateBookCommandHandler(IBookRepository bookRepository,
                                      ILogger<UpdateBookCommandHandler> logger,
                                      IMapper mapper) : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
{
    private IBookRepository _bookRepository { get; set; } = bookRepository;
    private IMapper _mapper { get; set; } = mapper;
    private ILogger<UpdateBookCommandHandler> _logger { get; set; } = logger;

    public async Task<UpdateBookResponse> Handle(UpdateBookRequest updateBookRequest, CancellationToken cancellationToken)
    {
        var existingBook = await _bookRepository.ByIdAsync(updateBookRequest.Id);
        if (existingBook == null)
        {
            _logger.LogError($"Book not found - {updateBookRequest.Id}");
            throw new NotFoundException("Book not found.");
        }

        existingBook = _mapper.Map(updateBookRequest, existingBook);

        await _bookRepository.UpdateAsync(existingBook);

        return new UpdateBookResponse("Book Updated.");
    }
}