using FluentValidation;
using Microservice.Book.Api.Data.Repository.Interfaces;

namespace Microservice.Book.Api.MediatR.GetBook;

public class GetBookValidator : AbstractValidator<GetBookRequest>
{
    private readonly IBookRepository _bookRepository;

    public GetBookValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;

        RuleFor(getBookRequest => getBookRequest).MustAsync(async (getBookRequest, cancellation) => {
            return await BookExists(getBookRequest);
        }).WithMessage("Book not found");
    }

    protected async Task<bool> BookExists(GetBookRequest getBookRequest)
    { 
        return await _bookRepository.BookExistsAsync(getBookRequest.Id);
    }
}