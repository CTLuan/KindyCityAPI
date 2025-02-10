using KindyCity.Application;
using KindyCity.Infrastructure;
using KindyCity.Shared.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KindyCity.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKindyCityDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI(configuration).AddInfrastructureDI(configuration);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://openapi.kindycity.edu.vn", "http://10.84.104.12:87", "https://localhost:8000")
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });
            });
            var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
            if (jwtSettings is null)
            {
                throw new InvalidOperationException("JWT settings are missing or invalid in the configuration.");
            }
            services.AddSingleton(jwtSettings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidIssuer = jwtSettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                };
            });
            var redisSettings = configuration.GetSection("Redis").Get<RedisSettings>();
            if (redisSettings == null)
            {
                throw new InvalidOperationException("Redis settings are missing or invalid in the configuration.");
            }
            services.AddSingleton(redisSettings);
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisSettings.ConnectionString;
                options.InstanceName = redisSettings.InstanceName;
            });
            return services;
        }
    }
}
