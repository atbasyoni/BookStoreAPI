using BookStore.Core.Features.Books.DTOs;
using BookStore.Core.Helper;
using BookStore.Data.Models.Products.Books;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Books.Commands
{
    public record UpdateBookCommand(int Id, string Title, string ISBN, string Description, DateTime PublicationDate, int Pages, int PublisherId, List<int> GenreIds) : IRequest;

    public record BookUpdatedEvent(UpdateBookCommand updateBookCommand) : INotification;

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMediator _mediator;

        public UpdateBookCommandHandler(IRepository<Book> bookRepository, IMediator mediator)
        {
            _bookRepository = bookRepository;
            _mediator = mediator;
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.MapOne<Book>();

            _bookRepository.Update(book);

            await _mediator.Publish(new BookUpdatedEvent(request));
        }
    }
}
