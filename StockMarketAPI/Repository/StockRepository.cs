using Microsoft.EntityFrameworkCore;
using StockMarketAPI.Data;
using StockMarketAPI.Interfaces;
using StockMarketAPI.Models;

namespace StockMarketAPI.Repository
{
	public class StockRepository : IStockRepository
	{
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
			_context = context;
        }

        public Task<List<Stock>> GetAllAsync()
		{
			return _context.Stocks.ToListAsync();
		}
	}
}
