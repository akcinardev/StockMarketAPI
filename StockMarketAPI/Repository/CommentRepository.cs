﻿using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using StockMarketAPI.Data;
using StockMarketAPI.Interfaces;
using StockMarketAPI.Models;

namespace StockMarketAPI.Repository
{
	public class CommentRepository : ICommentRepository
	{
		private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

		public async Task<Comment> CreateAsync(Comment commentModel)
		{
			await _context.Comments.AddAsync(commentModel);
			await _context.SaveChangesAsync();
			return commentModel;
		}

		public async Task<List<Comment>> GetAllAsync()
		{
			return await _context.Comments.ToListAsync();
		}

		public async Task<Comment?> GetByIdAsync(int id)
		{
			return await _context.Comments.FindAsync(id);
		}
	}
}
