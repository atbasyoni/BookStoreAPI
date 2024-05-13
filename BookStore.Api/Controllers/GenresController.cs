using AutoMapper;
using BookStore.Core;
using BookStore.Core.DTOs;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenresController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _unitOfWork.Genres.GetAllAsync();
            if(genres is null)
                return NotFound();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);
            if(genre is null)
                return NotFound();
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(GenreDTO model)
        {
            var genre = _mapper.Map<Genre>(model);
            await _unitOfWork.Genres.AddAsync(genre);
            await _unitOfWork.Complete();
            return Ok(genre);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(GenreDTO model)
        {
            var genre = await _unitOfWork.Genres.FindAsync(g => g.Id == model.Id);
            if(genre is null)
                return NotFound();

            genre = _mapper.Map<Genre>(model);
            _unitOfWork.Genres.Update(genre);
            await _unitOfWork.Complete();
            return Ok(genre);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var genre = _unitOfWork.Genres.Delete(id);
            if(genre is null)
                return NotFound();
            await _unitOfWork.Complete();
            return Ok(genre);
        }
    }
}
