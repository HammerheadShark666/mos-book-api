// Ignore Spelling: Mediatr

using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers;
using Microservice.Book.Api.Helpers.Exceptions;
using Microservice.Book.Api.MediatR.DeleteBook;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace Microservice.Book.Api.Test.Unit;

[TestFixture]
public class DeleteBookMediatrTests
{
    private Mock<IBookRepository> bookRepositoryMock = new();
    private Mock<ILogger<DeleteBookCommandHandler>> loggerMock = new();
    private ServiceCollection services = new();
    private ServiceProvider serviceProvider;
    private IMediator mediator;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteBookCommandHandler).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        services.AddScoped<IBookRepository>(sp => bookRepositoryMock.Object);
        services.AddScoped<ILogger<DeleteBookCommandHandler>>(sp => loggerMock.Object);
        serviceProvider = services.BuildServiceProvider();
        mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        services.Clear();
        serviceProvider.Dispose();
    }

    [Test]
    public async Task Delete_book_successfully_return_nothing()
    {
        Guid id = new("07c06c3f-0897-44b6-ae05-a70540e73a12");

        Domain.Book? book = new()
        {
            Id = id,
            Title = "Infinity Son",
            ISBN = "9780063376120",
            AuthorId = new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
            PublisherId = 3,
            SeriesId = 2,
            Summary = "Growing up in New York, brothers Emil and Brighton always idolized the Spell Walkers—a vigilante group sworn to rid the world of specters. While the Spell Walkers and other celestials are born with powers, specters take them, violently stealing the essence of endangered magical creatures.",
            Condition = "New",
            NumberInStock = 50,
            Price = 7.50m,
            Discount = null,
            DiscountTypeId = null,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        };

        bookRepositoryMock
                .Setup(x => x.ByIdAsync(id))
                .Returns(Task.FromResult(book));

        bookRepositoryMock
        .Setup(x => x.Delete(book));

        var deleteBookRequest = new DeleteBookRequest(id);
        var actualResult = await mediator.Send(deleteBookRequest);
    }

    [Test]
    public void Delete_book_fail_not_found_return_404()
    {
        Guid id = new("07c06c3f-0897-44b6-ae05-a70540e73a12");

        bookRepositoryMock
                .Setup(x => x.ByIdAsync(id));

        var deleteBookRequest = new DeleteBookRequest(id);

        var validationException = Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await mediator.Send(deleteBookRequest);
        });

        Assert.That(validationException.Message, Is.EqualTo("Book not found."));
    }
}