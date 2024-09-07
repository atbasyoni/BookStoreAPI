using BookStore.Core.Features.Genres.DTOs;
using BookStore.Core.Helper;
using BookStore.Data.Models.Products;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Genres.Commands
{
    public record class EditGenreCommand(GenreDTO genreDTO) : IRequest;

    public record GenreEditedEvent(GenreDTO genreDTO) : INotification;

    public class EditGenreCommandHandler : IRequestHandler<EditGenreCommand>
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMediator _mediator;

        public EditGenreCommandHandler(IRepository<Genre> genreRepository, IMediator mediator)
        {
            _genreRepository = genreRepository;
            _mediator = mediator;
        }

        public async Task Handle(EditGenreCommand request, CancellationToken cancellationToken)
        {
            var Genre = request.genreDTO.MapOne<Genre>();

            _genreRepository.Update(Genre);

            await _mediator.Publish(new GenreEditedEvent(request.genreDTO));
        }
    }
}
