using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Online_Movie.Exstensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connStr = builder.Configuration.GetConnectionString("LocalDb")!;
builder.Services.AddDbContext(connStr);
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	options.SignIn.RequireConfirmedAccount = false;
})
			   .AddDefaultTokenProviders()
			   .AddEntityFrameworkStores<OnlineMovieDBContext>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;

	serviceProvider.SeedRoles().Wait();
	serviceProvider.SeedAdmin().Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
