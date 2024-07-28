using System.ComponentModel.DataAnnotations;

namespace StockMarketAPI.DTOs.Comment
{
	public class CreateCommentDto
	{
		[Required]
		[MinLength(5, ErrorMessage = "Title must be at least 5 characters.")]
		[MaxLength(50, ErrorMessage = "Title can not be over 50 characters.")]
		public string Title { get; set; } = string.Empty;
		[Required]
		[MinLength(5, ErrorMessage = "Content must be at least 5 characters.")]
		[MaxLength(300, ErrorMessage = "Content can not be over 300 characters.")]
		public string Content { get; set; } = string.Empty;
	}
}
