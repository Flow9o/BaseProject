using BaseProject.Domain.Contracts;
using BaseProject.Domain.Model;
using BaseProject.Infrastructure.Database;

namespace BaseProject.Infrastructure.ServiceRunner;

public class BookmarkServiceRunner : IBookmarkServiceRunner
{
	private readonly BaseProjectDBContext _context;
	private readonly IBookmarkService _bookmarkService;

	public BookmarkServiceRunner(BaseProjectDBContext context, IBookmarkService bookmarkService)
	{
		_context = context;
		_bookmarkService = bookmarkService;
	}

	public async Task RunCreateBookmark(Bookmark request)
	{
		await _bookmarkService.CreateBookmark(request);
		await _context.SaveChangesAsync();
	}

	public async Task RunAssignBookmarkToUser(int bookmarkId, int userId)
	{
		await _bookmarkService.AssignBookmarkToUser(bookmarkId, userId);
		await _context.SaveChangesAsync();
	}
}