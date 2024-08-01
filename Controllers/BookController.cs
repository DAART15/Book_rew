using Book_rew.Interfaces;
using Book_rew.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_rew.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController(IBookService<Book> _bookService) : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllBooksAsync()
        {
            var response = await _bookService.GetAllBooksAsync();
            if (!response.IsSuccess)
            {
                if (response.Message == "404")
                {
                    return NotFound();
                }
            }
            return Ok(response.List);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetBookByIdAsync([FromQuery] int id)
        {
            var response = await _bookService.GetBookByIDAsync(id);
            if (!response.IsSuccess)
            {
                if (response.Message == "400")
                {
                    return BadRequest();
                }
                if (response.Message == "404")
                {
                    return NotFound();
                }
            }
            return Ok(response.Object);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult>CrateBookAsync([FromBody] Book book)
        {
            var response = await _bookService.CreateBookAsync(book);
            if (!response.IsSuccess)
            {
                if (response.Message == "400")
                {
                    return BadRequest();
                }
                if (response.Message == "404")
                {
                    return NotFound();
                }
            }
            return Created();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateBookAsync([FromBody] Book book)
        {
            var response = await _bookService.UpdateBookAsync(book);
            if (!response.IsSuccess)
            {
                if (response.Message == "400")
                {
                    return BadRequest();
                }
                if (response.Message == "404")
                {
                    return NotFound();
                }
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBookByIdAsync([FromQuery] int id)
        {
            var response = await _bookService.DeleteBookAsync(id);
            if (!response.IsSuccess)
            {
                if (response.Message == "400")
                {
                    return BadRequest();
                }
                if (response.Message == "404")
                {
                    return NotFound();
                }
            }
            return NoContent();
        }
    }
}
