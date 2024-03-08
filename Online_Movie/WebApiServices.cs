using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Online_Movie
{
	public class WebApiServices : IModule
	{
		public IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});

			var jwtOpts = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!;

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme )
				.AddJwtBearer(o =>
				{
					o.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = jwtOpts.Issuer,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.Key)),
						ClockSkew = TimeSpan.Zero,
						SaveSigninToken = true,
					};
				});

			services.AddAuthorization(opts => {

				opts.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
					  .RequireAuthenticatedUser().Build();
			} ); 

			services.AddSwaggerGen(setup =>
			{
				// Include 'SecurityScheme' to use JWT Authentication
				var jwtSecurityScheme = new OpenApiSecurityScheme
				{
					BearerFormat = "JWT",
					Name = "JWT Authentication",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = JwtBearerDefaults.AuthenticationScheme,
					Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

					Reference = new OpenApiReference
					{
						Id = JwtBearerDefaults.AuthenticationScheme,
						Type = ReferenceType.SecurityScheme
					}
				};

				setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

				setup.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{ jwtSecurityScheme, Array.Empty<string>() }
				});

			});
			services.AddHangfire(config =>
			{
				config.UseSqlServerStorage(configuration.GetConnectionString("LocalDb"));
			});

			services.AddHangfireServer();
			return services;
		}
	}
}
