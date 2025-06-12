using BaseProject.Domain.Model;

namespace BaseProject.Domain.Contracts;

public interface IUserServiceRunner
{
	Task RunCreateUser(User entity);
}