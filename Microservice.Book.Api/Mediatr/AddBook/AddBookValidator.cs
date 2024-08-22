using FluentValidation;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Interfaces;

namespace Microservice.Book.Api.MediatR.AddBook;

public class AddBookValidator : AbstractValidator<AddBookRequest>
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookHelper _bookHelper;

    public AddBookValidator(IBookRepository bookRepository, IBookHelper bookHelper)
    {
        _bookRepository = bookRepository;
        _bookHelper = bookHelper;

        RuleFor(addBookRequest => addBookRequest).Must((addBookRequest, cancellation) =>
        {
            return _bookHelper.ValidISBN13(addBookRequest.Isbn);
        }).WithMessage("Invalid ISBN code");

        RuleFor(addBookRequest => addBookRequest).MustAsync(async (addBookRequest, cancellation) =>
        {
            return await IsbnExists(addBookRequest.Isbn);
        }).WithMessage("A book with this isbn already exists");

        RuleFor(addBookRequest => addBookRequest.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(1, 150).WithMessage("Title length between 1 and 150.");

        RuleFor(addBookRequest => addBookRequest.Summary)
                .NotEmpty().WithMessage("Summary is required.")
                .Length(1, 2000).WithMessage("Summary length between 1 and 2000.");
    }

    protected async Task<bool> IsbnExists(string isbn)
    {
        return !await _bookRepository.IsbnExistsAsync(isbn);
    }
}