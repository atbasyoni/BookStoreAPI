using BookStore.Core.Features.Books.DTOs;
using BookStore.Core.Helper;
using BookStore.Data.Models.Products.Books;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Books.Commands
{
    public record class AddBookCommand(string Title, string ISBN, string Description, DateTime PublicationDate, int Pages, int PublisherId, List<int> GenreIds) : IRequest<BookDTO>;

    public record BookAddedEvent(BookDTO bookDTO) : INotification;

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDTO>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMediator _mediator;

        public AddBookCommandHandler(IRepository<Book> bookRepository, IMediator mediator)
        {
            _bookRepository = bookRepository;
            _mediator = mediator;
        }

        public async Task<BookDTO> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.MapOne<Book>();

            book = await _bookRepository.AddAsync(book);

            var bookDTO = book.MapOne<BookDTO>();

            await _mediator.Publish(new BookAddedEvent(bookDTO));

            return bookDTO;
        }
    }
}
