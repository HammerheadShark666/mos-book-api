using MediatR;  

namespace Microservice.Book.Api.MediatR.SearchBookTitle;

public record SearchBookTitleRequest(string Criteria) : IRequest<SearchBookTitleResponse>;