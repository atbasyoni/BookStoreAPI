using BookStore.Data.Models.Products.Books;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Books.Commands
{
    public record class DeleteBookCommand(int id) : IRequest;

    public record BookDeletedEvent(int id) : INotification;

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMediator _mediator;

        public DeleteBookCommandHandler(IRepository<Book> bookRepository, IMediator mediator)
        {
            _bookRepository = bookRepository;
            _mediator = mediator;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            _bookRepository.Delete(request.id);

            await _mediator.Publish(new BookDeletedEvent(request.id));
        }
    }
}