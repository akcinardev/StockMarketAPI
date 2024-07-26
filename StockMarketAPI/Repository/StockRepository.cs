﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StockMarketAPI.Data;
using StockMarketAPI.DTOs.Stock;
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

		public async Task<Stock> CreateAsync(Stock stockModel)
		{
			await _context.Stocks.AddAsync(stockModel);
			await _context.SaveChangesAsync();
			return stockModel;
		}

		public async Task<Stock?> DeleteAsync(int id)
		{
			var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

			if (stockModel == null)
			{
				return null;
			}

			_context.Stocks.Remove(stockModel);
			await _context.SaveChangesAsync();
			return stockModel;
		}

		public async Task<List<Stock>> GetAllAsync()
		{
			return await _context.Stocks.ToListAsync();
		}

		public async Task<Stock?> GetByIdAsync(int id)
		{
			return await _context.Stocks.FindAsync(id);
		}

		public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
		{
			var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

			if (existingStock == null)
			{
				return null;
			}

			existingStock.Symbol = stockDto.Symbol;
			existingStock.CompanyName = stockDto.CompanyName;
			existingStock.Purchase = stockDto.Purchase;
			existingStock.LastDiv = stockDto.LastDiv;
			existingStock.Industry = stockDto.Industry;
			existingStock.MarketCap = stockDto.MarketCap;

			await _context.SaveChangesAsync();

			return existingStock;
		}
	}
}
