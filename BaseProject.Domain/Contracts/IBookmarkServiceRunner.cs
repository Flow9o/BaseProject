using BaseProject.Domain.Model;

namespace BaseProject.Domain.Contracts;

public interface IBookmarkServiceRunner
{
	Task RunCreateBookmark(Bookmark request);
	Task RunAssignBookmarkToUser(int bookmarkId, int userId);
}