using Arenda.WebAPI.Infrastructure.Mappings;

namespace Arenda.WebAPI.Infrastructure.Configurations
{
    public static partial class WebConfigurations
    {
        public static IServiceCollection AddMapProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(x =>
            {
                x.AddProfile<ApproveApplicationProfile>();
                x.AddProfile<AuthenticateProfile>();
                x.AddProfile<CreateConstructionProfile>();
                x.AddProfile<CreateOrderProfile>();
                x.AddProfile<GetApplicationsProfile>();
                x.AddProfile<GetConstructionProfile>();
                x.AddProfile<GetConstructionsProfile>();
                x.AddProfile<GetEndDateProfile>();
                x.AddProfile<GetFilterConstructionsProfile>();
                x.AddProfile<GetUserOrdersProfile>();
                x.AddProfile<GetUserProfile>();
                x.AddProfile<RefreshTokenProfile>();
                x.AddProfile<RegistrationProfile>();
                x.AddProfile<UpdateConstructionProfile>();
                x.AddProfile<UpdateUserProfile>();
                
            });

            return services;
        }
    }
}
