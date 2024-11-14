using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Application.Exceptions;
using RockPaperScissorsLizardSpock.Application.Interfaces;
using RockPaperScissorsLizardSpock.Domain.Extensions;

namespace RockPaperScissorsLizardSpock.Infrastructure.Services
{
    public class RandomNumberService : IRandomNumberService
    {
        private readonly HttpClient _httpClient;
        public RandomNumberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetRandomNumberAsync()
        {
            var response = await _httpClient.GetAsync("random");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            if(responseString.TryParseJson<RandomNumberResponseDto>(out var randomNumberResponse) == false)
            {
                throw new ExternalServiceException("Failed to parse random number response.");
            }
            
            return randomNumberResponse.RandomNumber;
        }
    }

}
