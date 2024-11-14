using System.Text.Json.Serialization;
namespace RockPaperScissorsLizardSpock.Application.Dtos
{
    public class PlayerChoiceDto
    {
        [JsonPropertyName("player")]
        public int Id { get; set; }

    }
}
