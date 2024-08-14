using Book_rew.DTOs;
using Book_rew.Interfaces;
using Book_rew.Models;
using Book_rew.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_rew.Controllers
{
    [Route("/api/admin/")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "69a926f5-733b-4411-93d4-5748a051edd8")]
    public class AdminController(IReviewService _reviewService, IBookService<Book> _bookService) : ControllerBase
    {
        [HttpGet("reviews")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllRewiews()
        {
            var response = await _reviewService.GetAllReviews();
            if (!response.IsSuccess)
            {
                return StatusCode((int)response.StatusCode, response.Message);
            }
            return StatusCode((int)response.StatusCode, response.List);
        }
        [HttpPost("books")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CrateBookAsync([FromBody] BookDto book)
        {
            var response = await _bookService.CreateBookAsync(book);
            return StatusCode((int)response.StatusCode, response.Message);
        }
        [HttpPut("books")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateBookAsync([FromBody] Book book)
        {
            var response = await _bookService.UpdateBookAsync(book);
            return StatusCode((int)response.StatusCode, response.Message);
        }
        [HttpDelete("books/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBookByIdAsync(int id)
        {
            var response = await _bookService.DeleteBookAsync(id);
            return StatusCode((int)response.StatusCode, response.Message); ;
        }
        [HttpGet("books")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllBooksAsync()
        {
            var response = await _bookService.GetAllBooksAsync();
            if (!response.IsSuccess)
            {
                return StatusCode((int)response.StatusCode, response.Message);
            }
            return StatusCode((int)response.StatusCode, response.List);
        }
    }
}
