using System.Text.Json.Serialization;

namespace RockPaperScissorsLizardSpock.Application.Dtos
{
    public class GameResultDto
    {
        public int Id { get; set; }
        public int? PlayerId { get; set; }

        [JsonPropertyName("player")]
        public int PlayerChoiceId { get; set; }
        [JsonPropertyName("computer")]
        public int ComputerChoiceId { get; set; }

        [JsonPropertyName("results")]
        public string Result { get; set; }
        public DateTime PlayedAt { get; set; }

        public bool IncludeInScore { get; set; }


        public string? PlayerName { get; set; }
        public string PlayerChoiceName { get; set; }
        public string ComputerChoiceName { get; set; }
        public string Time => PlayedAt.ToString(format: "G");

    }
}
