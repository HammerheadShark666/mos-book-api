using AutoMapper;

namespace Microservice.Book.Api.MediatR.UpdateBook;

public class UpdateBookMapper : Profile
{
    public UpdateBookMapper()
    {
        base.CreateMap<UpdateBookRequest, Microservice.Book.Api.Domain.Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(m => m.LastUpdated, o => o.MapFrom(s => DateTime.Now));
    }
}