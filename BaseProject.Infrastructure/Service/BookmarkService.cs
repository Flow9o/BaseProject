using BaseProject.Domain.Contracts;
using BaseProject.Domain.Model;
using BaseProject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Service;

public class BookmarkService : IBookmarkService
{
	private readonly BaseProjectDBContext _context;

	public BookmarkService(BaseProjectDBContext context)
	{
		_context = context;
	}

	public async Task<List<Bookmark>> GetAllBookmarks()
	{
		return await _context.Bookmarks.ToListAsync();
	}

	public async Task CreateBookmark(Bookmark request)
	{
		await _context.Bookmarks.AddAsync(request);
	}
	
	public async Task AssignBookmarkToUser(int bookmarkId, int userId)
	{
		var bookmark = await _context.Bookmarks
			.Include(b => b.Users)
			.FirstOrDefaultAsync(b => b.Id == bookmarkId);

		if (bookmark == null)
			throw new Exception($"Bookmark mit ID {bookmarkId} wurde nicht gefunden.");

		var user = await _context.Users
			.Include(u => u.Bookmarks)
			.FirstOrDefaultAsync(u => u.Id == userId);

		if (user == null)
			throw new Exception($"User mit ID {userId} wurde nicht gefunden.");

		if (bookmark.Users.All(u => u.Id != userId))
		{
			bookmark.Users.Add(user);
		}
	}
}