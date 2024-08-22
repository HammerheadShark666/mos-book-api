using AutoMapper;

namespace Microservice.Book.Api.MediatR.GetBook;

public class GetBookMapper : Profile
{
    public GetBookMapper()
    {
        base.CreateMap<Api.Domain.Book, GetBookResponse>();
    }
}