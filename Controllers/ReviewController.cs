using Azure;
using Book_rew.DTOs;
using Book_rew.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_rew.Controllers
{
    [Route("api/books/{bookId}/reviews ")]
    [ApiController]
    //[Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "69a926f5-733b-4411-93d4-5748a051edd8")]
    public class ReviewController(IReviewService _reviewService) : ControllerBase
    {
        [HttpGet("all")]
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
    }
}
