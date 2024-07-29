using StockMarketAPI.Models;

namespace StockMarketAPI.Interfaces
{
	public interface ITokenService
	{
		string CreateToken(AppUser appUser);
	}
}
