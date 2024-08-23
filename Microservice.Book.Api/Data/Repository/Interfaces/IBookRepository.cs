namespace Microservice.Book.Api.Data.Repository.Interfaces;

public interface IBookRepository
{
    Task<Domain.Book> AddAsync(Domain.Book book);
    Task UpdateAsync(Domain.Book book);
    Task Delete(Domain.Book book);
    Task<Domain.Book> ByIdAsync(Guid id);
    Task<List<Domain.Book>> SearchTitleAsync(string criteria);
    Task<bool> IsbnExistsAsync(string isbn);
    Task<bool> IsbnExistsAsync(Guid id, string isbn);
}