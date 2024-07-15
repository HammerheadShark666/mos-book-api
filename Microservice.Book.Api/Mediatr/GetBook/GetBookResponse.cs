namespace Microservice.Book.Api.MediatR.GetBook;

public record GetBookResponse(Guid Id, string Title, string Isbn, string Author, string Publisher,
                              string Series, string Summary, string Condition, int NumberInStock,
                              decimal? Price, decimal? Discount);