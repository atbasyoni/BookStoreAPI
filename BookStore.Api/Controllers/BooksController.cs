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
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync();
            if (books is null)
                return NotFound();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if(book is null)
                return NotFound();
            return Ok(book);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(BookDTO model)
        {
            var newBook = _mapper.Map<Book>(model);
            await _unitOfWork.Books.AddAsync(newBook);
            await _unitOfWork.Complete();
            return Ok(newBook);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, BookDTO model)
        {
            var book = await _unitOfWork.Books.FindAsync(b => b.Id == id);
            if(book is null)
                return NotFound(model);

            _mapper.Map(model, book);
            _unitOfWork.Books.Update(book);
            await _unitOfWork.Complete();
            return Ok(book);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var book = _unitOfWork.Books.Delete(id);
            if(book is null)
                return NotFound();

            await _unitOfWork.Complete();
            return Ok(book);
        }
    }
}
