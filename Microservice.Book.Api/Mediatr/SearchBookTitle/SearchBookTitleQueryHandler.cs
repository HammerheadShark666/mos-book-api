using AutoMapper;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;

namespace Microservice.Book.Api.MediatR.SearchBookTitle;

public class SearchBookTitleQueryHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<SearchBookTitleRequest, SearchBookTitleResponse>
{
    public async Task<SearchBookTitleResponse> Handle(SearchBookTitleRequest request, CancellationToken cancellationToken)
    {
        var books = await bookRepository.SearchTitleAsync(request.Criteria) ?? throw new NotFoundException($"Books not found for id - '{request.Criteria}'");
        return mapper.Map<SearchBookTitleResponse>(books);
    }
}