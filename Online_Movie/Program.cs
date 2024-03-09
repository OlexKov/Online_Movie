using Hangfire;
using Online_Movie;
using Online_Movie.Exstensions;
using Online_Movie.ModuleRegistration;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

builder.Services.RegisterModules(builder.Configuration);

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

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.UseHangfireDashboard("/dash");

JobConfigurator.AddJobs();

app.MapControllers();

app.Run();
