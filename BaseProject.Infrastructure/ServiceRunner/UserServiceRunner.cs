using BaseProject.Domain.Contracts;
using BaseProject.Domain.Model;
using BaseProject.Infrastructure.Database;

namespace BaseProject.Infrastructure.ServiceRunner;

public class UserServiceRunner : IUserServiceRunner
{
	private readonly BaseProjectDBContext _context;
	private readonly IUserService _userService;
	
	public UserServiceRunner(BaseProjectDBContext context, IUserService userService)
	{
		_context = context;
		_userService = userService;
	}
	
	public async Task RunCreateUser(User entity)
	{
		await _userService.CreateUser(entity);
		await _context.SaveChangesAsync();
	}
}