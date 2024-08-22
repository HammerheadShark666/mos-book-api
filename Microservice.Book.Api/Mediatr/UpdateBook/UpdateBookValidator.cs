using FluentValidation;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Helpers.Interfaces;

namespace Microservice.Book.Api.MediatR.UpdateBook;

public class UpdateBookValidator : AbstractValidator<UpdateBookRequest>
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookHelper _bookHelper;

    public UpdateBookValidator(IBookRepository bookRepository, IBookHelper bookHelper)
    {
        _bookRepository = bookRepository;
        _bookHelper = bookHelper;

        RuleFor(updateBookRequest => updateBookRequest).Must((updateBookRequest, cancellation) =>
        {
            return _bookHelper.ValidISBN13(updateBookRequest.Isbn);
        }).WithMessage("Invalid ISBN code");

        RuleFor(updateBookRequest => updateBookRequest).MustAsync(async (updateBookRequest, cancellation) =>
        {
            return await IsbnExists(updateBookRequest.Id, updateBookRequest.Isbn);
        }).WithMessage("A book with this isbn already exists");

        RuleFor(updateBookRequest => updateBookRequest.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(1, 150).WithMessage("Title length between 1 and 150.");

        RuleFor(updateBookRequest => updateBookRequest.Summary)
                .NotEmpty().WithMessage("Summary is required.")
                .Length(1, 2000).WithMessage("Summary length between 1 and 2000.");

        RuleFor(updateBookRequest => updateBookRequest).Must((updateBookRequest, cancellation) =>
        {
            return _bookHelper.ValidDiscount(updateBookRequest.Price, updateBookRequest.Discount, updateBookRequest.DiscountTypeId);
        }).WithMessage("Discount would make the book free.");
    }

    protected async Task<bool> IsbnExists(string isbn)
    {
        return !await _bookRepository.IsbnExistsAsync(isbn);
    }

    protected async Task<bool> IsbnExists(Guid id, string isbn)
    {
        return !await _bookRepository.IsbnExistsAsync(id, isbn);
    }
}