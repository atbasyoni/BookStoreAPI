using BookStore.API.ViewModels;
using BookStore.Core.Features.Books.Commands;
using BookStore.Core.Features.Books.Queries;
using BookStore.Core.Helper;
using BookStore.Core.ViewModels.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel> GetBookById(int id)
        {
            var bookDTO = await _mediator.Send(new GetBookByIdQuery(id));
            var bookViewModel = bookDTO.MapOne<BookViewModel>();
            return ResultViewModel.Sucess(bookViewModel);
        }

        [HttpPost]
        public async Task<ResultViewModel> AddBook(AddBookCommand command)
        {


            var bookDTO = await _mediator.Send(command);
            var bookViewModel = bookDTO.MapOne<BookViewModel>();
            return ResultViewModel.Sucess(bookViewModel);
        }

        [HttpPut]
        public async Task<ResultViewModel> UpdateBook(UpdateBookCommand command)
        {
            await _mediator.Send(command);
            return ResultViewModel.Sucess(true);
        }

        [HttpDelete]
        public async Task<ResultViewModel> DeleteBook(int id)
        {
            await _mediator.Send(new DeleteBookCommand(id));
            return ResultViewModel.Sucess(true);
        }
    }
}
