using StockMarketAPI.Models;

namespace StockMarketAPI.Interfaces
{
	public interface IStockRepository
	{
		Task<List<Stock>> GetAllAsync();
	}
}
