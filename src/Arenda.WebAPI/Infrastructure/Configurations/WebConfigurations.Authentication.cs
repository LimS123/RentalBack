using Arenda.WebAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Arenda.WebAPI.Infrastructure.Configurations
{
    public static partial class WebConfigurations
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {
            ArgumentNullException.ThrowIfNull(appSettings.AuthSettings, nameof(appSettings.AuthSettings));

            var authSettings = appSettings.AuthSettings;

            services
                .AddAuthorization()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    ArgumentNullException.ThrowIfNull(authSettings.EncryptionKey, nameof(authSettings.EncryptionKey));
                    ArgumentNullException.ThrowIfNull(authSettings.Issuer, nameof(authSettings.Issuer));

                    var encryptionKey = authSettings.EncryptionKey;
                    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(encryptionKey));

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = symmetricSecurityKey,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = authSettings.Issuer,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidAudiences = authSettings.ValidAudiences,
                        ValidateAudience = authSettings.ValidateAudience
                    };

                    if (authSettings.ValidateAudience && authSettings.ValidAudiences?.Any() != true)
                    {
                        throw new ApplicationException("Valid Audiences is empty");
                    }

                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                });

            return services;
        }

    }
}
