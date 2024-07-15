namespace Microservice.Book.Api.MediatR.SearchBookTitle;

public record SearchBookTitleResponse(List<BookResponse> Books);

public record BookResponse(Guid Id, string Title, string Isbn, string Author, string Publisher,  
                           string Series, string Summary, string Condition, int NumberInStock, 
                           decimal? Price, decimal? Discount, string? DiscountType);