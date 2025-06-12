using Microsoft.AspNetCore.Mvc;
using System.Net;
using BaseProject.Domain.Contracts;
using BaseProject.Domain.Model;

namespace BaseProject.API.Controllers;

// [Authorize] - Use Only when JWT Auth is needed - ONLY IN TEST - NOT IN PROD
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UserController : ControllerBase
{
	private readonly IUserServiceRunner _userServiceRunner;
	private readonly IUserService _userService;

	public UserController(IUserServiceRunner userServiceRunner, IUserService userService)
	{
		_userServiceRunner = userServiceRunner;
		_userService = userService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateUser([FromBody] User user)
	{
		try 
		{
			await _userServiceRunner.RunCreateUser(user);
			return Ok();

		}
		catch (Exception e)
		{
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet]
	[ProducesResponseType(typeof(List<User>), (int)HttpStatusCode.OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)] 
	public async Task<IActionResult> GetAllUsers()
	{
		try
		{
			var users = await _userService.GetAllUsers();
			if (users.Count == 0)
			{
				return NotFound();
			}
			return Ok(users);
		}
		catch (Exception e)
		{
			return StatusCode(500, e.Message);
		}
	}
}
