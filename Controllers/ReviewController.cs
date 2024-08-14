using Azure;
using Book_rew.DTOs;
using Book_rew.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_rew.Controllers
{
    [Route("api/books/{bookId}/reviews")]
    [ApiController]
    //[Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    public class ReviewController(IReviewService _reviewService) : ControllerBase
    {
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostRew([FromBody]ReviewDto reviewDto)
        {
            var response = await _reviewService.SaveReview(reviewDto);
            return StatusCode((int)response.StatusCode, response.Message);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetReviewsByBookId(int bookId)
        {
            var response = await _reviewService.GetReviewsByBookId(bookId);
            if (!response.IsSuccess)
            {
                return StatusCode((int)response.StatusCode, response.Message);
            }
            return StatusCode((int)response.StatusCode, response.List);
        }
        [HttpGet("{reviewId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetReviewByBookIdAndReviewId(int bookId,int reviewId)
        {
            var response = await _reviewService.GetReviewByBookIdAndReviewIdAsync(bookId, reviewId);
            if (!response.IsSuccess)
            {
                return StatusCode((int)response.StatusCode, response.Message);
            }
            return StatusCode((int)response.StatusCode, response.Object);
        }
    }
}
