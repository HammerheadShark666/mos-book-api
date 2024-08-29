using Microsoft.EntityFrameworkCore;

namespace Microservice.Book.Api.Data.Context;

public class BookDbContext(DbContextOptions<BookDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Author>().HasData(DefaultData.GetAuthorDefaultData());
        modelBuilder.Entity<Domain.Series>().HasData(DefaultData.GetSeriesDefaultData());
        modelBuilder.Entity<Domain.DiscountType>().HasData(DefaultData.GetDiscountTypeDefaultData());
        modelBuilder.Entity<Domain.Publisher>().HasData(DefaultData.GetPublisherDefaultData());
        modelBuilder.Entity<Domain.Book>().HasData(DefaultData.GetBookDefaultData());
    }
}