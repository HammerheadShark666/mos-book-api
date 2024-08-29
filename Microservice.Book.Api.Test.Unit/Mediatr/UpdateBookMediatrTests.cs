// Ignore Spelling: Mediatr

using FluentValidation;
using MediatR;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers;
using Microservice.Book.Api.Helpers.Exceptions;
using Microservice.Book.Api.Helpers.Interfaces;
using Microservice.Book.Api.MediatR.UpdateBook;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System.Reflection;

namespace Microservice.Book.Api.Test.Unit.Mediatr;

[TestFixture]
public class UpdateBookMediatrTests
{
    private readonly Mock<IBookRepository> bookRepositoryMock = new();
    private readonly ServiceCollection services = new();
    private readonly Mock<ILogger<UpdateBookCommandHandler>> loggerMock = new();
    private ServiceProvider serviceProvider;
    private IMediator mediator;

    private Api.Domain.Book book = new();
    private UpdateBookRequest updateBookRequest = new(Guid.Empty, "Infinity Son", "9780063376120",
                                                  new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
                                                       3, 2, "Infinity Son Summary", "New", 50, 7.50m, null, null);

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        services.AddValidatorsFromAssemblyContaining<UpdateBookValidator>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateBookCommandHandler).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        services.AddScoped(sp => bookRepositoryMock.Object);
        services.AddScoped<IBookHelper, BookHelper>();
        services.AddScoped<ILogger<UpdateBookCommandHandler>>(sp => loggerMock.Object);
        services.AddAutoMapper(Assembly.GetAssembly(typeof(UpdateBookMapper)));

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
            Id = new Guid("07c06c3f-0897-44b6-ae05-a70540e73a12"),
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

        updateBookRequest = new UpdateBookRequest(new Guid("07c06c3f-0897-44b6-ae05-a70540e73a12"), "Infinity Son",
                                            "9780063376120",
                                            new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
                                            3, 2,
                                            "Infinity Son Summary", "New",
                                            50, 7.50m,
                                            null, null);

        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync(updateBookRequest.Id, "9780063376120"))
                .Returns(Task.FromResult(false));

        bookRepositoryMock
                .Setup(x => x.UpdateAsync(book))
                .Returns(Task.FromResult(book));
    }

    [Test]
    public async Task Book_updated_return_success_message()
    {
        bookRepositoryMock
                .Setup(x => x.ByIdAsync(updateBookRequest.Id))
                .Returns(Task.FromResult(book));

        var actualResult = await mediator.Send(updateBookRequest);
        var expectedResult = "Book Updated.";

        Assert.That(actualResult.Message, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Book_not_updated_book_not_found_return_not_found_exception()
    {
        bookRepositoryMock
                .Setup(x => x.ByIdAsync(updateBookRequest.Id));

        Exception ex = Assert.ThrowsAsync<NotFoundException>(async () => await mediator.Send(updateBookRequest));
        var expectedResult = "Book not found.";

        Assert.That(ex.Message, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Book_not_updated_isbn_exists_exception_fail_message()
    {
        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync(updateBookRequest.Id, "9780063376120"))
                .Returns(Task.FromResult(true));

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await mediator.Send(updateBookRequest);
            });

        Assert.Multiple(() =>
        {
            Assert.That(validationException.Errors.Count, Is.EqualTo(1));
            Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("A book with this isbn already exists"));
        });
    }

    [Test]
    public void Book_not_updated_invalid_isbn_exception_fail_message()
    {
        bookRepositoryMock
                .Setup(x => x.IsbnExistsAsync(updateBookRequest.Id, "9780063376123"))
                .Returns(Task.FromResult(false));

        book.ISBN = "9780063376123";
        updateBookRequest = updateBookRequest with { Isbn = "9780063376123" };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateBookRequest);
        });

        Assert.Multiple(() =>
        {
            Assert.That(validationException.Errors.Count, Is.EqualTo(1));
            Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Invalid ISBN code"));
        });
    }

    [Test]
    public void Book_not_updated_no_title_exception_fail_message()
    {
        book.Title = "";
        updateBookRequest = updateBookRequest with { Title = "" };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateBookRequest);
        });

        Assert.Multiple(() =>
        {
            Assert.That(validationException.Errors.Count, Is.EqualTo(2));
            Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Title is required."));
            Assert.That(validationException.Errors.ElementAt(1).ErrorMessage, Is.EqualTo("Title length between 1 and 150."));
        });
    }

    [Test]
    public void Book_not_updated_title_too_big_exception_fail_message()
    {
        book.Title = new string('A', 151);
        updateBookRequest = updateBookRequest with { Title = new string('A', 151) };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateBookRequest);
        });

        Assert.Multiple(() =>
        {
            Assert.That(validationException.Errors.Count, Is.EqualTo(1));
            Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Title length between 1 and 150."));
        });
    }

    [Test]
    public void Book_not_updated_no_summary_exception_fail_message()
    {
        book.Summary = "";
        updateBookRequest = updateBookRequest with { Summary = "" };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateBookRequest);
        });

        Assert.Multiple(() =>
        {
            Assert.That(validationException.Errors.Count, Is.EqualTo(2));
            Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Summary is required."));
            Assert.That(validationException.Errors.ElementAt(1).ErrorMessage, Is.EqualTo("Summary length between 1 and 2000."));
        });
    }

    [Test]
    public void Book_not_updated_summary_too_big_exception_fail_message()
    {
        book.Summary = new string('A', 2001);
        updateBookRequest = updateBookRequest with { Summary = new string('A', 2001) };

        var validationException = Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await mediator.Send(updateBookRequest);
        });

        Assert.Multiple(() =>
        {
            Assert.That(validationException.Errors.Count, Is.EqualTo(1));
            Assert.That(validationException.Errors.ElementAt(0).ErrorMessage, Is.EqualTo("Summary length between 1 and 2000."));
        });
    }
}