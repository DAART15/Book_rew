using Book_rew.Interfaces;
using Book_rew.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book_rew.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Authorize]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "69a926f5-733b-4411-93d4-5748a051edd8")]
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
                    return NotFound(response.Message);
                }
            }
            return Ok(response.List);
        }
        //[HttpGet()]

        //public async Task<ActionResult> GetBookById()
        //{

        //}
    }
}
