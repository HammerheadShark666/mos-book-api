using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers;
using Microservice.Book.Api.MediatR.SearchBookTitle;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Reflection;

namespace Microservice.Book.Api.Test.Unit;

[TestFixture]
public class GetSearchBookTitleMediatrTests
{
    private Mock<IBookRepository> bookRepositoryMock = new();
    private ServiceCollection services = new();
    private ServiceProvider serviceProvider;
    private IMediator mediator;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(SearchBookTitleQueryHandler).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        services.AddScoped<IBookRepository>(sp => bookRepositoryMock.Object);
        services.AddAutoMapper(Assembly.GetAssembly(typeof(SearchBookTitleMapper)));

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
    public async Task Search_book_title_successfully_return_books()
    {
        Guid id1 = new("07c06c3f-0897-44b6-ae05-a70540e73a12");

        var book1 = new Domain.Book
        {
            Id = id1,
            Title = "Infinity Son",
            ISBN = "9780063376120",
            AuthorId = new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
            PublisherId = 3,
            SeriesId = 2,
            Summary = "Growing up in New York, brothers Emil and Brighton always idolized the Spell Walkers—a vigilante group sworn to rid the world of specters. While the Spell Walkers and other celestials are born with powers, specters take them, violently stealing the essence of endangered magical creatures.",
            Condition = "New",
            NumberInStock = 50,
            Price = 7.50m
        };

        Guid id2 = new("6131ce7e-fb11-4608-a3d3-f01caee2c465");

        var book2 = new Domain.Book
        {
            Id = id2,
            Title = "Infinity Reaper",
            ISBN = "9780062882318",
            AuthorId = new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
            PublisherId = 3,
            SeriesId = 2,
            Summary = "Emil and Brighton Rey defied the odds. They beat the Blood Casters and escaped with their lives–or so they thought. When Brighton drank the Reaper’s Blood, he believed it would make him invincible, but instead the potion is killing him.",
            Condition = "New",
            NumberInStock = 34,
            Price = 8.50m
        };

        var books = new List<Domain.Book>() { book1, book2 };

        var criteria = "Infinity";

        bookRepositoryMock
                .Setup(x => x.SearchTitleAsync(criteria))
                .Returns(Task.FromResult(books));

        var searchBookTitleRequest = new SearchBookTitleRequest(criteria);
        var actualResult = await mediator.Send(searchBookTitleRequest);

        Assert.That(actualResult.Books.Count, Is.EqualTo(2));

        var actualBook1 = actualResult.Books[0];
        Assert.That(actualBook1.Id, Is.EqualTo(id1));
        Assert.That(actualBook1.Title, Is.EqualTo("Infinity Son"));
        Assert.That(actualBook1.NumberInStock, Is.EqualTo(50));
        Assert.That(actualBook1.Price, Is.EqualTo(7.50m));

        var actualBook2 = actualResult.Books[1];
        Assert.That(actualBook2.Id, Is.EqualTo(id2));
        Assert.That(actualBook2.Title, Is.EqualTo("Infinity Reaper"));
        Assert.That(actualBook2.NumberInStock, Is.EqualTo(34));
        Assert.That(actualBook2.Price, Is.EqualTo(8.50m));
    }

    [Test]
    public async Task Search_book_title_non_found_return_empty_list()
    {
        var books = new List<Domain.Book>();

        var criteria = "Infinity";

        bookRepositoryMock
                .Setup(x => x.SearchTitleAsync(criteria))
                .Returns(Task.FromResult(books));

        var searchBookTitleRequest = new SearchBookTitleRequest(criteria);
        var actualResult = await mediator.Send(searchBookTitleRequest);

        Assert.That(actualResult.Books, Is.Empty);
    }
}