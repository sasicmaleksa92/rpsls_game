using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Application.Interfaces.Services;
using RockPaperScissorsLizardSpock.Domain.Enums;
using RockPaperScissorsLizardSpock.Domain.Helpers;

namespace RockPaperScissorsLizardSpock.Infrastructure.Services.Game
{
    public class GameResultService : IGameResultService
    {
        private readonly IGameChoiceService _gameChoiceService;

        public GameResultService(IGameChoiceService gameChoiceService)
        {
            _gameChoiceService = gameChoiceService;
        }

        async Task<GameResultDto> IGameResultService.PlayGameWithComputer(int playerChoiceId)
        {
            GameChoiceDto computerChoice = await _gameChoiceService.GetRandomGameChoiceAsync();
            var gameResult = GameRuleHelper.DetermineWinner((GameChoicesEnum)playerChoiceId, (GameChoicesEnum)computerChoice.Id);

            var gameResultDto = new GameResultDto
            {
                PlayerChoiceId = playerChoiceId,
                PlayerChoiceName = ((GameChoicesEnum)playerChoiceId).ToString(),
                ComputerChoiceId = computerChoice.Id,
                ComputerChoiceName = computerChoice.Name,
                Result = gameResult.ToString(),
                PlayedAt = DateTime.Now
            };

            return gameResultDto;
        }

    }

}
