using BookStore.Core.Features.Genres.DTOs;
using BookStore.Core.Helper;
using BookStore.Data.Models.Products;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Genres.Commands
{
    public record class AddGenreCommand(GenreCreateDTO genreCreateDTO) : IRequest<GenreDTO>;

    public record GenreAddedEvent(GenreDTO genreDTO) : INotification;

    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, GenreDTO>
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMediator _mediator;

        public AddGenreCommandHandler(IRepository<Genre> genreRepository, IMediator mediator)
        {
            _genreRepository = genreRepository;
            _mediator = mediator;
        }

        public async Task<GenreDTO> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = request.genreCreateDTO.MapOne<Genre>();

            genre = await _genreRepository.AddAsync(genre);

            var genreDTO = genre.MapOne<GenreDTO>();

            await _mediator.Publish(new GenreAddedEvent(genreDTO));

            return genreDTO;
        }
    }
}
