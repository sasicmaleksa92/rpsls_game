using FluentAssertions;
using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Application.Dtos.Authentication;
using RockPaperScissorsLizardSpock.IntegrationTests.Common;
using System.Net;

namespace RockPaperScissorsLizardSpock.IntegrationTests
{
    [Collection("Integration Tests")]
    public class AuthControllerTests : TestBase
    {
        public AuthControllerTests(TestServer server) : base(server)
        {
        }

        [Fact]
        public async Task LoginUser()
        {
            var response = await _client.PostAsJsonAsync($"{TestData.AuthEndpoint}/login", new
            {
                Username = TestData.TestUserUsername,
                Password = TestData.TestUserPassword
            });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
            result?.AccessToken.Should().NotBeNullOrEmpty();
        }

        //[Fact]
        //public async Task BadCredentialsShouldReturnUnauthorized()
        //{
        //    var response = await _client.PostAsJsonAsync(TestData.AuthEndpoint, new
        //    {
        //        Username = TestData.TestUserUsername,
        //        Password = TestData.TestUserPassword
        //    });

        //    response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        //}
    }
}
