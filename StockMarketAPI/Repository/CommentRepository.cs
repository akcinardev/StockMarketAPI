﻿using Microsoft.EntityFrameworkCore;
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

		public async Task<Comment?> DeleteAsync(int id)
		{
			var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

			if (commentModel == null)
			{
				return null;
			}

			_context.Comments.Remove(commentModel);
			await _context.SaveChangesAsync();
			return commentModel;
		}

		public async Task<List<Comment>> GetAllAsync()
		{
			return await _context.Comments.Include(c => c.AppUser).ToListAsync();
		}

		public async Task<Comment?> GetByIdAsync(int id)
		{
			return await _context.Comments.Include(c => c.AppUser).FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
		{
			var existingComment = await _context.Comments.FindAsync(id);
			if (existingComment == null)
			{
				return null;
			}

			existingComment.Title = commentModel.Title;
			existingComment.Content = commentModel.Content;

			await _context.SaveChangesAsync();
			return existingComment;
		}
	}
}
