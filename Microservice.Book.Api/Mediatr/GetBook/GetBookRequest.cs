using MediatR;

namespace Microservice.Book.Api.MediatR.GetBook;

public record GetBookRequest(Guid Id) : IRequest<GetBookResponse>;