using StockMarketAPI.DTOs.Stock;
using StockMarketAPI.Models;

namespace StockMarketAPI.Mappers
{
	public static class StockMappers
	{
		public static StockDto ToStockDto(this Stock stockModel)
		{
			return new StockDto()
			{
				Id = stockModel.Id,
				Symbol = stockModel.Symbol,
				CompanyName = stockModel.CompanyName,
				Purchase = stockModel.Purchase,
				LastDiv = stockModel.LastDiv,
				Industry = stockModel.Industry,
				MarketCap = stockModel.MarketCap
			};
		}
	}
}
