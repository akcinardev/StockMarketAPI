using Microsoft.AspNetCore.Mvc;
using StockMarketAPI.Interfaces;
using StockMarketAPI.Mappers;

namespace StockMarketAPI.Controllers
{
	[Route("api/comment")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var comments = await _commentRepo.GetAllAsync();

			var commentDto = comments.Select(s => s.ToCommentDto());

			return Ok(commentDto);
		}
    }
}
