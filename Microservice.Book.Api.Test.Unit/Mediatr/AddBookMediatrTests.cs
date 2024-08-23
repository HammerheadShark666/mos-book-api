// Ignore Spelling: Mediatr

using FluentValidation;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers;
using Microservice.Book.Api.Helpers.Interfaces;
using Microservice.Book.Api.MediatR.AddBook;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Reflection;

namespace Microservice.Book.Api.Test.Unit.Mediatr;

[TestFixture]
public class AddBookMediatrTests
{
    private Mock<IBookRepository> bookRepositoryMock = new();
    private ServiceCollection services = new();
    private ServiceProvider serviceProvider;
    private IMediator mediator;

    private Api.Domain.Book book = new();
    private AddBookRequest addBookRequest = new(Guid.Empty, "Infinity Son", "9780063376120",
                                                  new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
                                                       3, 2, "Infinity Son Summary", "New", 50, 7.50m, null, null);

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        services.AddValidatorsFromAssemblyContaining<AddBookValidator>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddBookCommandHandler).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        services.AddScoped(sp => bookRepositoryMock.Object);
        services.AddScoped<IBookHelper, BookHelper>();
        services.AddAutoMapper(Assembly.GetAssembly(typeof(AddBookMapper)));

        serviceProvider = services.BuildServiceProvider();
        mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        services.Clear();
        serviceProvider.Dispose();
    }

    [SetUp]
    public void Setup()
    {
        book = new Api.Domain.Book()
        {
            Id = Guid.Empty,
            Title = "Infinity Son",
            ISBN = "9780063376120",
            AuthorId = new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
            PublisherId = 3,
            SeriesId = 2,
            Summary = "Infinity Son Summary",
            Condition = "New",
            NumberInStock = 50,
            Price = 7.50m,
            Discount = null,
            DiscountTypeId = null
        };

        addBookRequest = new AddBookRequest(Guid.Empty, "Infinity Son",
                                            "9780063376120",
                                            new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
                                            3, 2,
                                            "Infinity Son Summary", "New",
                                            50, 7.50m,
                                            null, null);
    }

    [Test]
    public async Task Book_added_return_success_message()
    {
        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync("9780063376120"))
                .Returns(Task.FromResult(false));

        bookRepositoryMock
                .Setup(x => x.AddAsync(book))
                .Returns(Task.FromResult(book));

        var actualResult = await mediator.Send(addBookRequest);

        Assert.IsInstanceOf(typeof(Guid), actualResult.Id);
    }

    [Test]
    public void Book_not_added_isbn_exists_exception_fail_message()
    {
        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync("9780063376120"))
                .Returns(Task.FromResult(true));

        bookRepositoryMock
                .Setup(x => x.AddAsync(book))
                .Returns(Task.FromResult(book));

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await mediator.Send(addBookRequest);
            });

        Assert.That(validationException.Errors.Count, Is.EqualTo(1));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("A book with this isbn already exists"));
    }

    [Test]
    public void Book_not_added_invalid_isbn_exception_fail_message()
    {
        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync("9780063376123"))
                .Returns(Task.FromResult(false));

        bookRepositoryMock
                .Setup(x => x.AddAsync(book))
                .Returns(Task.FromResult(book));

        book.ISBN = "9780063376123";
        addBookRequest = addBookRequest with { Isbn = "9780063376123" };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(addBookRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(1));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Invalid ISBN code"));
    }

    [Test]
    public void Book_not_added_no_title_exception_fail_message()
    {
        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync("9780063376120"))
                .Returns(Task.FromResult(false));

        bookRepositoryMock
                .Setup(x => x.AddAsync(book))
                .Returns(Task.FromResult(book));

        book.Title = "";
        addBookRequest = addBookRequest with { Title = "" };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(addBookRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(2));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Title is required."));
        Assert.That(validationException.Errors.ElementAt(1).ErrorMessage, Is.EqualTo("Title length between 1 and 150."));
    }

    [Test]
    public void Book_not_added_title_too_big_exception_fail_message()
    {
        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync("9780063376120"))
                .Returns(Task.FromResult(false));

        bookRepositoryMock
                .Setup(x => x.AddAsync(book))
                .Returns(Task.FromResult(book));

        book.Title = new string('A', 151);
        addBookRequest = addBookRequest with { Title = new string('A', 151) };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(addBookRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(1));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Title length between 1 and 150."));
    }

    [Test]
    public void Book_not_added_no_summary_exception_fail_message()
    {
        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync("9780063376120"))
                .Returns(Task.FromResult(false));

        bookRepositoryMock
                .Setup(x => x.AddAsync(book))
                .Returns(Task.FromResult(book));

        book.Summary = "";
        addBookRequest = addBookRequest with { Summary = "" };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(addBookRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(2));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Summary is required."));
        Assert.That(validationException.Errors.ElementAt(1).ErrorMessage, Is.EqualTo("Summary length between 1 and 2000."));
    }

    [Test]
    public void Book_not_added_summary_too_big_exception_fail_message()
    {
        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync("9780063376120"))
                .Returns(Task.FromResult(false));

        bookRepositoryMock
                .Setup(x => x.AddAsync(book))
                .Returns(Task.FromResult(book));

        book.Summary = new string('A', 2001);
        addBookRequest = addBookRequest with { Summary = new string('A', 2001) };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(addBookRequest);
        });

        Assert.That(validationException.Errors.Count, Is.EqualTo(1));
        Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Summary length between 1 and 2000."));
    }
}