using StockMarketAPI.Models;

namespace StockMarketAPI.Interfaces
{
	public interface ICommentRepository
	{
		Task<List<Comment>> GetAllAsync();
	}
}
