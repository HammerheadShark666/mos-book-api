using AutoMapper;

namespace Microservice.Book.Api.MediatR.SearchBookTitle;

public class SearchBookTitleMapper : Profile
{
    public SearchBookTitleMapper()
    {
        base.CreateMap<List<Domain.Book>, SearchBookTitleResponse>()
            .ForCtorParam(nameof(SearchBookTitleResponse.Books),
                    opt => opt.MapFrom(src => src));

        base.CreateMap<Api.Domain.Book, BookResponse>()
            .ForCtorParam(nameof(BookResponse.Author),
                    opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.MiddleName} {src.Author.Surname}"))
            .ForCtorParam(nameof(BookResponse.Series),
                    opt => opt.MapFrom(src => src.Series.Name))
            .ForCtorParam(nameof(BookResponse.Publisher),
                    opt => opt.MapFrom(src => src.Publisher.Name))
            .ForCtorParam(nameof(BookResponse.DiscountType),
                    opt => opt.MapFrom(src => src.DiscountType.Name));
    }
}