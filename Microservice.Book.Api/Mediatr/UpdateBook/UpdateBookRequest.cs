using MediatR;

namespace Microservice.Book.Api.MediatR.UpdateBook;

public record UpdateBookRequest(Guid Id, string Title, string Isbn, Guid AuthorId, int? PublisherId, int? SeriesId,
                                string Summary, string Condition, int NumberInStock, decimal? Price,
                                decimal? Discount, int? DiscountTypeId) : IRequest<UpdateBookResponse>;