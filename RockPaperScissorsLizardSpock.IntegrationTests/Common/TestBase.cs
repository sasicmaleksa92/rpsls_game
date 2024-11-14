using Microsoft.AspNetCore.Mvc.Testing;
using RockPaperScissorsLizardSpock.Application.Dtos.Authentication;

namespace RockPaperScissorsLizardSpock.IntegrationTests.Common
{
    [Collection("Integration Tests")]
    public abstract class TestBase(TestServer server) : IAsyncLifetime
    {
        private readonly TestServer _server = server;
        private AsyncServiceScope _scope;
        protected IServiceProvider _services;
        protected HttpClient _client;

        public async Task InitializeAsync()
        {
            _client = _server.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost/")
            });
            _scope = _server.Services.CreateAsyncScope();
            _services = _scope.ServiceProvider;

            var dataSeedService = _services.GetRequiredService<IDataSeedService>();
            await dataSeedService.SeedDataAsync();

        }        

        protected async Task<string> GetLoginUserToken()
        {
            var response = await _client.PostAsJsonAsync($"{TestData.AuthEndpoint}/login", new
            {
                Username = TestData.TestUserUsername,
                Password = TestData.TestUserPassword
            });
            var result = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
            return result.AccessToken;
        }


        public async Task DisposeAsync()
        {
            await _scope.DisposeAsync();
        }
    }
}
