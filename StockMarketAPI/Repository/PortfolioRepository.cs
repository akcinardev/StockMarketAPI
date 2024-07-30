﻿using Microsoft.EntityFrameworkCore;
using StockMarketAPI.Data;
using StockMarketAPI.Interfaces;
using StockMarketAPI.Models;

namespace StockMarketAPI.Repository
{
	public class PortfolioRepository : IPortfolioRepository
	{
		private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
		{
			return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
				.Select(stock => new Stock
				{
					Id = stock.StockId,
					Symbol = stock.Stock.Symbol,
					CompanyName = stock.Stock.CompanyName,
					Purchase = stock.Stock.Purchase,
					LastDiv = stock.Stock.LastDiv,
					Industry = stock.Stock.Industry,
					MarketCap = stock.Stock.MarketCap,
				}).ToListAsync();
		}
	}
}
