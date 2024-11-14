using System.Text.Json.Serialization;

namespace RockPaperScissorsLizardSpock.Application.Dtos
{
    /// <summary>
    /// Represents the result of a single game round in a game, including player choices, 
    /// computer choices, results, and the time the game was played.
    /// </summary>
    public class GameResultDto
    {

        /// <summary>
        /// Gets or sets the unique identifier for the game result.
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the player’s unique identifier. Can be null if the player is not logged in.
        /// </summary>
        public int? PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the player's choice in the game, represented by an identifier.
        /// This is the player's choice for the current round (e.g., 1, 2, 3..).
        /// </summary>
        [JsonPropertyName("player")]
        public int PlayerChoiceId { get; set; }

        /// <summary>
        /// Gets or sets the computer's choice in the game, represented by an identifier.
        /// This is the result of the random selection for the current round.
        /// </summary>
        [JsonPropertyName("computer")]
        public int ComputerChoiceId { get; set; }

        /// <summary>
        /// Gets or sets the result of the game round as a string.
        /// The result could be "Player Wins", "Computer Wins", or "Draw".
        /// </summary>
        [JsonPropertyName("results")]
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the game round was played.
        /// This is in DateTime format, representing the exact time the game occurred.
        /// </summary>
        public DateTime PlayedAt { get; set; }

        /// <summary>
        /// Indicates whether the game result should be included in the player's score.
        /// If set to true, the result will be counted towards the player's score.
        /// </summary>
        public bool IncludeInScore { get; set; }

        /// <summary>
        /// Gets or sets the name of the player. This can be null if the player is not logged in or identified.
        /// </summary>
        public string? PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the player's choice as a string (e.g., "Rock", "Paper", "Scissors").
        /// </summary>
        public string PlayerChoiceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the computer's choice as a string (e.g., "Rock", "Paper", "Scissors").
        /// </summary>
        public string ComputerChoiceName { get; set; }

        /// <summary>
        /// Gets the formatted time when the game was played as a string.
        /// The format used is the standard "G" (General) DateTime format.
        /// </summary>
        public string Time => PlayedAt.ToString(format: "G");
    }
}
