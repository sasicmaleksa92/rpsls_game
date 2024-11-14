using FluentAssertions;
using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.IntegrationTests.Common;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace RockPaperScissorsLizardSpock.IntegrationTests
{
    [Collection("Integration Tests")]
    public class GameControllerTests : TestBase
    {
        public GameControllerTests(TestServer server) : base(server)
        {
        }

        [Trait("Type", "Integration")]
        [Fact]
        public async Task GetGameChoicesShouldReturnInsertedGameChoices()
        {
            var response = await _client.GetAsync($"{TestData.GameControllerEndpoint}/choices");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadFromJsonAsync<List<GameChoiceDto>>();
            var gameChoicesNames = content.Select(x => x.Name);
            gameChoicesNames.Should().Equal(TestData.GameChoices);
        }

        [Trait("Type", "Integration")]
        [Fact]
        public async Task GetRandomGameChoiceShouldReturnValidGameChoice()
        {
            var response = await _client.GetAsync($"{TestData.GameControllerEndpoint}/choice");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<GameChoiceDto>();
            TestData.GameChoices.Should().Contain(result.Name);

        }

        [Trait("Type", "Integration")]
        [Fact]
        public async Task GuestUserPlayWithComputerShouldReturnValidResults()
        {
            var playerChoiceId = 3;

            var response = await _client.SendAsync(GetHttpRequestMessageForGamePlayEndpoint(playerChoiceId));

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<GameResultDto>();

            result.PlayerName.Should().Be(null);
            result.PlayerChoiceId.Should().Be(playerChoiceId);
            result.PlayerChoiceName.Should().Be("Scissors");
            result.ComputerChoiceId.Should().BeInRange(1, 5);

        }


        [Trait("Type", "Integration")]
        [Fact]
        public async Task LoggedInUserPlayWithComputerShouldReturnValidResults()
        {
            var accessToken = await GetLoginUserToken();
            var playerChoiceId = 4;

            var response = await _client.SendAsync(GetHttpRequestMessageForGamePlayEndpoint(playerChoiceId, accessToken));

            //Assertions
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<GameResultDto>();

            result.PlayerName.Should().Be(TestData.TestUserUsername);
            result.PlayerChoiceId.Should().Be(playerChoiceId);
            result.PlayerChoiceName.Should().Be("Lizard");
            result.ComputerChoiceId.Should().BeInRange(1, 5);

        }

        #region Helper methods
        private HttpRequestMessage GetHttpRequestMessageForGamePlayEndpoint(int playerChoiceId, string? accessToken = null)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://localhost/{TestData.GameControllerEndpoint}/play"),
                Content = new StringContent(JsonSerializer.Serialize(new PlayerChoiceDto { Id = playerChoiceId }), Encoding.UTF8, "application/json"),
            };

            if (!string.IsNullOrEmpty(accessToken))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return requestMessage;
        }
        #endregion

    }
}
