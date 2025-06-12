using BaseProject.Domain.Model;

namespace BaseProject.Domain.Contracts;

public interface IUserService
{
	Task<List<User>> GetAllUsers();
	Task CreateUser(User entity);
}