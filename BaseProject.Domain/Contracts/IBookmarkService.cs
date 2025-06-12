using BaseProject.Domain.Model;

namespace BaseProject.Domain.Contracts;

public interface IBookmarkService
{
	Task<List<Bookmark>> GetAllBookmarks();
	Task CreateBookmark(Bookmark request);
	Task AssignBookmarkToUser(int bookmarkId, int userId);
}