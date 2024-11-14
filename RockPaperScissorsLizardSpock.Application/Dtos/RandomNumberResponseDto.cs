using Newtonsoft.Json;

namespace RockPaperScissorsLizardSpock.Application.Dtos
{
    public class RandomNumberResponseDto
    {
        [JsonProperty("random_number")]
        public int RandomNumber { get; set; }
    }
}
