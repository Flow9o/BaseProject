using BaseProject.Infrastructure.Service;
using BaseProject.Infrastructure.ServiceRunner;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace BaseProject.API.Tests.User;

public sealed class UserServiceTests : BaseProjectTestBase
{
	// [Fact]
 //    public async Task? GetUserTest_Success() 
 //    {
	//     var testbase = new UserServiceTests();
	//     var dbContext = testbase.DbContext;
	// 	    
	// 	// create dummy user and add to table in context
	//     dbContext.Users.Add(new Domain.Model.User
	//     {
	// 	    Id = 1,
	// 	    FirstName = "TestUser",
	// 	    LastName = "TestUser",
	// 	    EMail = "TestUser@test.com",
	// 	    Password = "1234",
	//     });
	//     
	//     await dbContext.SaveChangesAsync();
	//     var userService = Substitute.For<UserService>(dbContext);
	//     var response = await userService.GetUser(1);
 //
	//     Assert.NotNull(response);
	//     Assert.Equal(1, response.Id);
 //    }
 //    
 //    
 //    
 //    [Fact]
	// public async Task? GetUserTest_Failure() 
	// {
	// 	var testbase = new UserServiceTests();
	// 	var dbContext = testbase.DbContext;
	// 	
	// 	// create dummy user and add to table in context
	// 	dbContext.Users.Add(new Domain.Model.User
	// 	{
	// 		Id = 1,
	// 		FirstName = "TestUser",
	// 		LastName = "TestUser",
	// 		EMail = "TestUser@test.com",
	// 		Password = "1234",
	// 	});
	//     
	// 	await dbContext.SaveChangesAsync();
	// 	var userService = Substitute.For<UserService>(dbContext);
	// 	var response = await userService.GetUser(2);
 //
	// 	Assert.Null(response);
	// }
 //
	// [Fact]
	// public async Task? GetUserByEmailTest_Success()
	// {
	// 	var testbase = new UserServiceTests();
	// 	var dbContext = testbase.DbContext;
 //
	// 	dbContext.Users.Add(new Domain.Model.User
	// 	{
	// 		Id = 1,
	// 		FirstName = "TestUser",
	// 		LastName = "TestUser",
	// 		EMail = "TESTUSER@test.com",
	// 		Password = "1234",
	// 	});
	// 	await dbContext.SaveChangesAsync();
	// 	var userService = Substitute.For<UserService>(dbContext);
	// 	var response = await userService.GetUserByEmail("TESTUSER@test.com");
	// 	
	// 	Assert.NotNull(response);
	// 	Assert.Equal("TESTUSER@test.com", response.EMail);
	// }
 //
	// [Fact]
	// public async Task? GetUserByEmailTest_Failure()
	// {
	// 	var testbase = new UserServiceTests();
	// 	var dbContext = testbase.DbContext;
 //
	// 	dbContext.Users.Add(new Domain.Model.User
	// 	{
	// 		Id = 1,
	// 		FirstName = "TestUser",
	// 		LastName = "TestUser",
	// 		EMail = "TESTUSER@test.com",
	// 		Password = "1234",
	// 		IdDepartment = 0,
	// 	});
	// 	await dbContext.SaveChangesAsync();
	// 	var userService = Substitute.For<UserService>(dbContext);
	// 	var response = await userService.GetUserByEmail("");
	// 	
	// 	Assert.Null(response);
	// 	
	// }
	
	// [Fact]
	// public async Task? DeleteUserTest_Success()
	// {
	// 	// Arrange
	// 	var testbase = new UserServiceTests();
	// 	var dbContext = testbase.DbContext;
	//
	// 	dbContext.Users.Add(new Domain.Model.User
	// 	{
	// 		Id = 34,
	// 		FirstName = "TestUser",
	// 		LastName = "TestUser",
	// 		EMail = "",
	// 		Password = "1234",
	// 	});
	// 	await dbContext.SaveChangesAsync();
	// 	var userService = Substitute.For<UserService>(dbContext);
	// 	var userServiceRunner = Substitute.For<UserServiceRunner>(dbContext, userService);
	// 	
	// 	//Act
	// 	await userServiceRunner.RunDeleteUser(34);
	// 	var response = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == 34);
	// 	
	// 	//Assert
	// 	Assert.Null(response);
	// }
	
}


