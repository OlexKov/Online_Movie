using BusinessLogic;
using DataAccess.Extensions;
using Online_Movie.Exstensions;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Configuration.GetConnectionString("LocalDb")!;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext(connStr);
builder.Services.AddRepositories();
builder.Services.AddIdentityUser();
builder.Services.AddAutoMapper();
builder.Services.AddFluentValidator();
builder.Services.AddCustomServices();


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

app.UseStaticFiles();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
