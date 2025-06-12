
using System.Net;
using BaseProject.Domain.Contracts;
using BaseProject.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.API.Controllers;

// [Authorize] - Use Only when JWT Auth is needed - ONLY IN TEST - NOT IN PROD
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BookmarkController : ControllerBase
{
	private readonly IBookmarkService _bookmarkService;
	private readonly IBookmarkServiceRunner _bookmarkServiceRunner;

	public BookmarkController(IBookmarkService bookmarkService, IBookmarkServiceRunner bookmarkServiceRunner)
	{
		_bookmarkService = bookmarkService;
		_bookmarkServiceRunner = bookmarkServiceRunner;
	}

	[HttpPut]
	public async Task<IActionResult> CreateBookmark([FromBody] Bookmark bookmark)
	{
		try
		{
			await _bookmarkServiceRunner.RunCreateBookmark(bookmark);
			return Ok();
		}
		catch (Exception e)
		{
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet]
	[ProducesResponseType(typeof(List<Bookmark>), (int)HttpStatusCode.OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)] 
	public async Task<IActionResult> GetAllBookmarks()
	{
		try
		{
			var bookmarks = await _bookmarkService.GetAllBookmarks();
			
			if (bookmarks.Count == 0)
			{
				return NotFound();
			}
	
			return Ok(bookmarks);
		}
		catch (Exception e)
		{
			return StatusCode(500, e.Message);
		}
	}
	
	[HttpPost("{bookmarkId:int}/Users/{userId:int}")]
	public async Task<IActionResult> AssignBookmarkToUser([FromRoute] int bookmarkId, [FromRoute] int userId)
	{
		try
		{
			await _bookmarkServiceRunner.RunAssignBookmarkToUser(bookmarkId, userId);
			return Ok();
		}
		catch (Exception e)
		{
			return StatusCode(500, e.Message);
		}
	}
}