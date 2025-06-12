using BaseProject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace BaseProject.API.Tests;

public class BaseProjectTestBase
{
	protected BaseProjectDBContext DbContext { get; set; }

	protected BaseProjectTestBase()
	{
		// Create the In-Memory-Datenbankoptions for DbContext
		var uniqueDatabaseName = $"BaseProject_{Guid.NewGuid()}";

		var dbContextOptions = new DbContextOptionsBuilder<BaseProjectDBContext>()
			.UseInMemoryDatabase(databaseName: uniqueDatabaseName)
			.Options;
		
		var config = Substitute.For<IConfiguration>();
		DbContext = new BaseProjectDBContext(dbContextOptions, config);
	}
}