using Microservice.Book.Api.Data.Context;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Book.Api.Data.Repository;

public class BookRepository(IDbContextFactory<BookDbContext> dbContextFactory) : IBookRepository
{
    public async Task<Domain.Book> AddAsync(Domain.Book book)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        await db.AddAsync(book);
        db.SaveChanges();

        return book;
    }

    public async Task UpdateAsync(Domain.Book book)
    {
        using var db = dbContextFactory.CreateDbContext();

        db.Books.Update(book);
        await db.SaveChangesAsync();
    }

    public async Task Delete(Domain.Book book)
    {
        using var db = dbContextFactory.CreateDbContext();

        db.Books.Remove(book);
        await db.SaveChangesAsync();
    }

    public async Task<List<Domain.Book>> SearchTitleAsync(string criteria)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        return await db.Books
                        .AsNoTracking()
                        .Where(o => o.Title.Contains(criteria))
                        .Include(e => e.Author)
                        .Include(e => e.Publisher)
                        .Include(e => e.Series)
                        .Include(e => e.DiscountType)
                        .OrderBy(e => e.Title)
                        .ToListAsync();
    }

    public async Task<Domain.Book> ByIdAsync(Guid id)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        return await db.Books
                        .Where(o => o.Id.Equals(id))
                        .Include(e => e.Author)
                        .Include(e => e.Publisher)
                        .Include(e => e.Series)
                        .Include(e => e.DiscountType)
                        .SingleOrDefaultAsync() ?? throw new NotFoundException("Book not found.");
    }

    public async Task<bool> IsbnExistsAsync(string isbn)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        return await db.Books.AsNoTracking().AnyAsync(x => x.ISBN.Equals(isbn));
    }

    public async Task<bool> IsbnExistsAsync(Guid id, string isbn)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        return await db.Books.AsNoTracking().AnyAsync(x => x.ISBN.Equals(isbn) && !x.Id.Equals(id));
    }
}