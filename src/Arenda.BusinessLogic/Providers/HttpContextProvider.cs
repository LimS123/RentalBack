using Arenda.BusinessLogic.Contracts.Providers;
using Microsoft.AspNetCore.Http;

namespace Arenda.BusinessLogic.Providers
{
    public class HttpContextProvider : IHttpContextProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            Guid.TryParse(_httpContextAccessor.HttpContext?.User.Identity?.Name, out Guid userId);

            return userId;
        }
    }
}
