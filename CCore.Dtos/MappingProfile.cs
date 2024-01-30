using System;
using AutoMapper;
using CCore.Entities;

namespace CCore.Dtos.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()

    {
        CreateMap<Category, CategoryDto>()
                             .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
        CreateMap<Category, CategoryDto>().ReverseMap()
                             .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

        CreateMap<Book, BookDto>();
        CreateMap<BookDto, Book>();
    }
}
