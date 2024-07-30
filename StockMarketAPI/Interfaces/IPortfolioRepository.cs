using StockMarketAPI.Models;

namespace StockMarketAPI.Interfaces
{
	public interface IPortfolioRepository
	{
		Task<List<Stock>> GetUserPortfolio(AppUser user);
		Task<Portfolio> CreateAsync(Portfolio portfolio);
	}
}
