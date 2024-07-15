using MediatR;

namespace Microservice.Book.Api.MediatR.DeleteBook;

public record DeleteBookRequest(Guid Id) : IRequest<Unit>;                            