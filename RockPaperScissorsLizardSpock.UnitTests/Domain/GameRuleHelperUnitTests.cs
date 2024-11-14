namespace RockPaperScissorsLizardSpock.UnitTests.Domain
{
    using RockPaperScissorsLizardSpock.Domain.Enums;
    using RockPaperScissorsLizardSpock.Domain.Helpers;
    using Xunit;

    public class GameRuleHelperTests
    {
        [Theory]
        [InlineData(GameChoicesEnum.Rock, GameChoicesEnum.Rock, GameResultsEnum.Tie)]
        [InlineData(GameChoicesEnum.Paper, GameChoicesEnum.Paper, GameResultsEnum.Tie)]
        [InlineData(GameChoicesEnum.Scissors, GameChoicesEnum.Scissors, GameResultsEnum.Tie)]
        [InlineData(GameChoicesEnum.Lizard, GameChoicesEnum.Lizard, GameResultsEnum.Tie)]
        [InlineData(GameChoicesEnum.Spock, GameChoicesEnum.Spock, GameResultsEnum.Tie)]
        public void DetermineWinner_ShouldReturnTie_WhenChoicesAreEqual(GameChoicesEnum playerChoice, GameChoicesEnum computerChoice, GameResultsEnum expectedResult)
        {
            // Act
            var result = GameRuleHelper.DetermineWinner(playerChoice, computerChoice);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(GameChoicesEnum.Rock, GameChoicesEnum.Scissors, GameResultsEnum.Win)]
        [InlineData(GameChoicesEnum.Rock, GameChoicesEnum.Lizard, GameResultsEnum.Win)]
        [InlineData(GameChoicesEnum.Paper, GameChoicesEnum.Rock, GameResultsEnum.Win)]
        [InlineData(GameChoicesEnum.Paper, GameChoicesEnum.Spock, GameResultsEnum.Win)]
        [InlineData(GameChoicesEnum.Scissors, GameChoicesEnum.Paper, GameResultsEnum.Win)]
        [InlineData(GameChoicesEnum.Scissors, GameChoicesEnum.Lizard, GameResultsEnum.Win)]
        [InlineData(GameChoicesEnum.Lizard, GameChoicesEnum.Spock, GameResultsEnum.Win)]
        [InlineData(GameChoicesEnum.Lizard, GameChoicesEnum.Paper, GameResultsEnum.Win)]
        [InlineData(GameChoicesEnum.Spock, GameChoicesEnum.Scissors, GameResultsEnum.Win)]
        [InlineData(GameChoicesEnum.Spock, GameChoicesEnum.Rock, GameResultsEnum.Win)]
        public void DetermineWinner_ShouldReturnWin_WhenPlayerChoiceBeatsComputerChoice(GameChoicesEnum playerChoice, GameChoicesEnum computerChoice, GameResultsEnum expectedResult)
        {
            // Act
            var result = GameRuleHelper.DetermineWinner(playerChoice, computerChoice);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(GameChoicesEnum.Scissors, GameChoicesEnum.Rock, GameResultsEnum.Lose)]
        [InlineData(GameChoicesEnum.Lizard, GameChoicesEnum.Rock, GameResultsEnum.Lose)]
        [InlineData(GameChoicesEnum.Rock, GameChoicesEnum.Paper, GameResultsEnum.Lose)]
        [InlineData(GameChoicesEnum.Spock, GameChoicesEnum.Paper, GameResultsEnum.Lose)]
        [InlineData(GameChoicesEnum.Paper, GameChoicesEnum.Scissors, GameResultsEnum.Lose)]
        [InlineData(GameChoicesEnum.Lizard, GameChoicesEnum.Scissors, GameResultsEnum.Lose)]
        [InlineData(GameChoicesEnum.Spock, GameChoicesEnum.Lizard, GameResultsEnum.Lose)]
        [InlineData(GameChoicesEnum.Paper, GameChoicesEnum.Lizard, GameResultsEnum.Lose)]
        [InlineData(GameChoicesEnum.Scissors, GameChoicesEnum.Spock, GameResultsEnum.Lose)]
        [InlineData(GameChoicesEnum.Rock, GameChoicesEnum.Spock, GameResultsEnum.Lose)]
        public void DetermineWinner_ShouldReturnLose_WhenComputerChoiceBeatsPlayerChoice(GameChoicesEnum playerChoice, GameChoicesEnum computerChoice, GameResultsEnum expectedResult)
        {
            // Act
            var result = GameRuleHelper.DetermineWinner(playerChoice, computerChoice);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }

}