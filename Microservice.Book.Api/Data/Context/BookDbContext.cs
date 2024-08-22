using Microservice.Book.Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Book.Api.Data.Contexts;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

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

//add-migration
//update-database

//azurite --silent --location c:\azurite --debug c:\azurite\debug.log