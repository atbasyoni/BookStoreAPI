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
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            if (authors is null)
                return NotFound();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(id);
            if (author is null)
                return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AuthorDTO model)
        {
            var newAuthor = _mapper.Map<Author>(model);
            await _unitOfWork.Authors.AddAsync(newAuthor);
            await _unitOfWork.Complete();
            return Ok(newAuthor);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, AuthorDTO model)
        {
            var author = await _unitOfWork.Authors.FindAsync(a => a.Id == id);
            if(author is null)
                return NotFound();

            _mapper.Map(model, author);
            _unitOfWork.Authors.Update(author);
            await _unitOfWork.Complete();
            return Ok(author);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var author = _unitOfWork.Authors.Delete(id);
            if (author is null)
                return NotFound();
            await _unitOfWork.Complete();
            return Ok(author);
        }
    }
}
