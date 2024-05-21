using AutoMapper;
using BookStore.Core.DTOs;
using BookStore.Core.DTOs.Authors;
using BookStore.Core.DTOs.Books;
using BookStore.Core.Models.Accounts;
using BookStore.Core.Models.Products;
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
            // Book Mapper
            CreateMap<Book, BookDTO>();
            
            CreateMap<BookDTO, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CreateBookDTO, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateBookDTO, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            //Author Mapper
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            //Genre Mapper
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ApplicationUser, RegisterDTO>();
            CreateMap<RegisterDTO, ApplicationUser>();
        }
    }
}
