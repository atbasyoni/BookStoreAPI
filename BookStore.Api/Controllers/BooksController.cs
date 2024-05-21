using AutoMapper;
using BookStore.Core;
using BookStore.Core.DTOs.Books;
using BookStore.Core.Models.Products.Books;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            return Ok(await _unitOfWork.Books.GetAllAsync());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Books.GetByIdAsync(id));
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBookAsync(CreateBookDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newBook = _mapper.Map<Book>(model);
            
            await _unitOfWork.Books.AddAsync(newBook);
            await _unitOfWork.Complete();
            
            return Ok(newBook);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateBookAsync(int id, BookDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await _unitOfWork.Books.FindAsync(b => b.Id == id);
           
            if(book is null)
                return NotFound(model);

            _mapper.Map(model, book);
            
            _unitOfWork.Books.Update(book);
            await _unitOfWork.Complete();
            
            return Ok(book);
        }

        [HttpDelete]
        [Authorize]
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
