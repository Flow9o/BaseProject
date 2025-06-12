using BaseProject.Domain.Contracts;
using BaseProject.Domain.Model;
using BaseProject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Service;

public class UserService : IUserService
{
	private readonly BaseProjectDBContext _context;

	public UserService(BaseProjectDBContext context)
	{
		_context = context;
	}

	public async Task<List<User>> GetAllUsers()
	{
		return await _context.Users.ToListAsync();
	}
	
	public async Task CreateUser(User entity)
	{
		await _context.Users.AddAsync(entity);
	}
}