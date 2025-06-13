using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using BaseProject.Domain.Contracts;
using BaseProject.Infrastructure.Database;
using BaseProject.Infrastructure.Service;
using BaseProject.Infrastructure.ServiceRunner;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Register the UserService for dependency injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserServiceRunner, UserServiceRunner>();

builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IBookmarkServiceRunner, BookmarkServiceRunner>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarServiceRunner, CarServiceRunner>();

// Configure the PostgreSQL DbContext
builder.Services.AddDbContext<BaseProjectDBContext>(options =>
	options.UseNpgsql(
			builder.Configuration.GetConnectionString("DefaultConnection"),
			b => b.MigrationsAssembly("BaseProject.Infrastructure")
		)
		.EnableDetailedErrors()
		.EnableSensitiveDataLogging());

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BaseProject API", Version = "v1" });
	// c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
	// {
	// 	Name = "Authorization",
	// 	Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
	// 	Scheme = "bearer",
	// 	BearerFormat = "JWT",
	// 	In = Microsoft.OpenApi.Models.ParameterLocation.Header,
	// 	Description = "JWT Authorization header using the Bearer scheme."
	// });
	// c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
	// {
	// 	{ new Microsoft.OpenApi.Models.OpenApiSecurityScheme { Reference = new Microsoft.OpenApi.Models.OpenApiReference { Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, Id = "Bearer" } }, new string[] { } }
	// });
	c.EnableAnnotations();
	c.CustomOperationIds(apiDesc =>
	{
		var result = apiDesc.TryGetMethodInfo(out MethodInfo methodInfo);
		if (!result)
			return null;
		var swaggerOperation = methodInfo.CustomAttributes
			.Where(w => w.AttributeType.Name == "SwaggerOperationAttribute")
			.FirstOrDefault();
		if (swaggerOperation != null)
		{
			var memberName = swaggerOperation.NamedArguments.FirstOrDefault()!.TypedValue.Value!.ToString();
			return memberName;
		}
		return methodInfo.Name;
	});

	c.ResolveConflictingActions(api =>
	{
		var x = api.First();
		return x;
	});
	
	
	// Registriere hier den benutzerdefinierten SchemaFilter
	c.SchemaFilter<MakeOptionalPropertiesRequiredAndNullableSchemaFilter>();
});

// JWT Authentication setup (uncomment if needed)
// builder.Services.AddAuthentication("JWTBearer")
// 	.AddJwtBearer("JWTBearer", options =>
// 	{
// 		options.IncludeErrorDetails = true;
// 		options.Authority = "YourAuthority";
// 		options.TokenValidationParameters = new TokenValidationParameters
// 		{
// 			ValidateIssuer = true,
// 			ValidateAudience = false,
// 			ValidateLifetime = true,
// 			ValidateIssuerSigningKey = false,
// 			ValidAudiences = new List<string> { "YourValidAudiences", },
// 			ValidIssuers = new List<string> { "YourValidIssuers", "YourValidIssuers" }
// 		};
// 	});

// Health check service
builder.Services.AddHealthChecks();

builder.Services.AddOpenApi();

var app = builder.Build();

// Migrate database on startup
// using (var scope = app.Services.CreateScope())
// {
// 	var dbContext = scope.ServiceProvider.GetRequiredService<BaseProjectDBContext>();
// 	dbContext.Database.Migrate(); // Apply migrations
// }

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


// Enable CORS for development (be more restrictive in production)
app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());

// Enable Authentication and Authorization (if using JWT)
// app.UseAuthentication();
// app.UseAuthorization();

// Map controllers
app.MapControllers();

// Health check endpoint
app.MapHealthChecks("/healthz");

// Open Swagger UI in the default browser automatically
// if (app.Environment.IsDevelopment())
// {
	var swaggerUrl = "http://localhost:5000/swagger/index.html";
	Process.Start(new ProcessStartInfo
	{
		FileName = swaggerUrl,
		UseShellExecute = true
	});
// }

app.Run();