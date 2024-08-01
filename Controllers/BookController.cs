using Book_rew.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_rew.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController(IBookService _bookService) : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllBooksAsync()
        {
            var response = await _bookService.GetAllBooksAsync();
            if (response.IsSuccess == false)
            {
                return NotFound(response.Message);
            }
            return Ok(response.BookList);
            
        }
    }
}
