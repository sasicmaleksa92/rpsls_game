using RockPaperScissorsLizardSpock.Domain.Entities.Identity;
using RockPaperScissorsLizardSpock.Domain.Enums;

namespace RockPaperScissorsLizardSpock.Domain.Entities
{
    public class GameResult
    {
        public int Id { get; set; }
        public int? PlayerId { get; set; }

        public int PlayerChoiceId { get; set; }

        public int ComputerChoiceId { get; set; }
        public GameResultsEnum Result { get; set; }

        public DateTime PlayedAt { get; set; }

        public bool IncludeInScore { get; set; }


        public GameChoice PlayerChoice { get; set; }

        public GameChoice ComputerChoice { get; set; }

        public IGamePlayer GamePlayer { get; set; }

    }
}
