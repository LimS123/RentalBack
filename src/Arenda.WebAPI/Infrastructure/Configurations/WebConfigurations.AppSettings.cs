
namespace Arenda.WebAPI.Infrastructure.Configurations
{
    public static partial class WebConfigurations
    {
        public static WebApplicationBuilder AddAppSettings(this WebApplicationBuilder appBuilder, IConfiguration configuration)
        {
            appBuilder.Host.ConfigureAppConfiguration(config =>
            {
                var prefix = configuration.GetSection("ApplicationPrefix").Value;
                config.AddEnvironmentVariables(prefix);
                config.Build();
            });

            return appBuilder;
        }
    }
}
