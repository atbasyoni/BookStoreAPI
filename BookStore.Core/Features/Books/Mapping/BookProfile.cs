using AutoMapper;
using BookStore.Core.Features.Books.Commands;
using BookStore.Core.Features.Books.DTOs;
using BookStore.Core.ViewModels.Books;
using BookStore.Data.Models.Products.Books;

namespace BookStore.Core.Features.Books.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<AddBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();

            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, BookViewModel>();
        }
    }
}
