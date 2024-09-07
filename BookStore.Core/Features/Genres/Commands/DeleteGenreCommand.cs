using BookStore.Data.Models.Products;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Genres.Commands
{
    public record class DeleteGenreCommand(int id) : IRequest;

    public record GenreDeletedEvent(int id) : INotification;

    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMediator _mediator;

        public DeleteGenreCommandHandler(IRepository<Genre> genreRepository, IMediator mediator)
        {
            _genreRepository = genreRepository;
            _mediator = mediator;
        }

        public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            _genreRepository.Delete(request.id);

            await _mediator.Publish(new GenreDeletedEvent(request.id));
        }
    }
}
