using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjectApi.Application.Interfaces.Tokens;
using ProjectApi.Infrastructure.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Infrastructure
{
	public static class Registration
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<TokenSettings>(configuration.GetSection("Jwt"));

			services.AddTransient<ITokenService, TokenService>();

			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}
			).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
			{
				opt.SaveToken = true;
				opt.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])),
					ValidIssuer = configuration["Jwt:Issuer"],
					ValidateLifetime = false,
					ValidAudience = configuration["Jwt:Audience"],
					ClockSkew = TimeSpan.Zero
				};
			});
		}
	}
}
