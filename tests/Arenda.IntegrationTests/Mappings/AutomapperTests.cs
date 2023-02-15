using Arenda.WebAPI;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.IntegrationTests.Mappings
{
    public class AutomapperTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly IServiceScope _scope;
        private readonly IMapper _mapper;

        public AutomapperTests(WebApplicationFactory<Program> factory)
        {
            _scope = factory.Services.CreateScope();
            _mapper = _scope.ServiceProvider.GetRequiredService<IMapper>();
        }

        [Fact]
        public void AutoMapper_Should_Have_Valid_Configuration()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
