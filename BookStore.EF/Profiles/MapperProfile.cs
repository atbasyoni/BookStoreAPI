using AutoMapper;
using BookStore.Core.DTOs;
using BookStore.Core.Models;
using BookStore.Core.Models.Products.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EF.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ApplicationUser, RegisterDTO>();
            CreateMap<RegisterDTO, ApplicationUser>();
        }
    }
}
