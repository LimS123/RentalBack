using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Infrastructure.Configurations;
using Arenda.WebAPI.Models;
using FluentValidation;

namespace Arenda.WebAPI.Infrastructure
{
    public static class WebApiServiceExtensions
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<AppSettings>(configuration.GetSection("AppSettings"))
                .Configure<JwtTokenOptions>(configuration.GetSection("JwtOptions"))
                .Configure<RefreshTokenOptions>(configuration.GetSection("RefreshOptions"));

            var appSettings = configuration
                .GetRequiredSection("AppSettings")
                .Get<AppSettings>();

            services
                .AddJwtAuthentication(appSettings)
                .AddHttpContextAccessor()
                .AddMapProfiles()
                .AddValidatorsFromAssembly(typeof(Program).Assembly)
                .AddHttpClient()
                .AddSwagger();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", builder => 
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());
            });

            return services;
        }
    }
}
