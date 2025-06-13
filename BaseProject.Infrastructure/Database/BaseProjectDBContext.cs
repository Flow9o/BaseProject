using System.Reflection;
using BaseProject.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BaseProject.Infrastructure.Database;

public class BaseProjectDBContext : DbContext
{
	private readonly IConfiguration _configuration;

	public BaseProjectDBContext(DbContextOptions<BaseProjectDBContext> options, IConfiguration configuration) : base(options)
	{
		_configuration = configuration;
	}
	
	public DbSet<User> Users { get; set; }
	public DbSet<Bookmark> Bookmarks { get; set; }
	public DbSet<Car> Cars { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			var connectionString = _configuration.GetConnectionString("DefaultConnection");
			optionsBuilder.UseNpgsql(connectionString);
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
		base.OnModelCreating(modelBuilder);
	}
}