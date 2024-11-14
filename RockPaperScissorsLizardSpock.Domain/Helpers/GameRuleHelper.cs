using RockPaperScissorsLizardSpock.Domain.Enums;

namespace RockPaperScissorsLizardSpock.Domain.Helpers
{
    public class GameRuleHelper
    {
        public static GameResultsEnum DetermineWinner(GameChoicesEnum playerChoice, GameChoicesEnum computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return GameResultsEnum.Tie;
            }

            switch (playerChoice, computerChoice)
            {
                case (GameChoicesEnum.Rock, GameChoicesEnum.Scissors):
                case (GameChoicesEnum.Rock, GameChoicesEnum.Lizard):
                case (GameChoicesEnum.Paper, GameChoicesEnum.Rock):
                case (GameChoicesEnum.Paper, GameChoicesEnum.Spock):
                case (GameChoicesEnum.Scissors, GameChoicesEnum.Paper):
                case (GameChoicesEnum.Scissors, GameChoicesEnum.Lizard):
                case (GameChoicesEnum.Lizard, GameChoicesEnum.Spock):
                case (GameChoicesEnum.Lizard, GameChoicesEnum.Paper):
                case (GameChoicesEnum.Spock, GameChoicesEnum.Scissors):
                case (GameChoicesEnum.Spock, GameChoicesEnum.Rock):
                    return GameResultsEnum.Win;
                default:
                    return GameResultsEnum.Lose;
            }
        }
    }
}

