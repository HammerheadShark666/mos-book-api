using AutoMapper;

namespace Microservice.Book.Api.MediatR.AddBook;

public class AddBookMapper : Profile
{
    public AddBookMapper()
    { 
        base.CreateMap<AddBookRequest, Microservice.Book.Api.Domain.Book>()
            .ForMember(m => m.Id, o => o.MapFrom(s => Guid.NewGuid())) 
            .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.PublisherId == null || src.PublisherId == 0 ? null : src.PublisherId))
            .ForMember(dest => dest.SeriesId, opt => opt.MapFrom(src => src.SeriesId == null || src.SeriesId == 0 ? null : src.SeriesId))
            .ForMember(dest => dest.DiscountTypeId, opt => opt.MapFrom(src => src.DiscountTypeId == null || src.DiscountTypeId == 0 ? null : src.DiscountTypeId));
    }
}