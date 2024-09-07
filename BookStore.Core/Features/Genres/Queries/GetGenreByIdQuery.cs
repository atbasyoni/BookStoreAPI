using BookStore.Core.Features.Genres.DTOs;
using BookStore.Core.Helper;
using BookStore.Data.Models.Products;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace GenreStore.Core.Features.Genres.Queries
{
    public record GetGenreByIdQuery(int id) : IRequest<GenreDTO>;

    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreDTO>
    {
        private readonly IRepository<Genre> _genreRepository;

        public GetGenreByIdQueryHandler(IRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<GenreDTO> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var Genre = await _genreRepository.GetByIdAsync(request.id);
            return Genre.MapOne<GenreDTO>();
        }
    }
}
