using BookStore.Core.Features.Books.DTOs;
using BookStore.Core.Helper;
using BookStore.Data.Models.Products.Books;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Books.Queries
{
    public record GetBookByIdQuery(int id) : IRequest<BookDTO>;
    
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly IRepository<Book> _bookRepository;

        public GetBookByIdQueryHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.id);
            return book.MapOne<BookDTO>();
        }
    }
}
