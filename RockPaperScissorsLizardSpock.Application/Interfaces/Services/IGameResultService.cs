using RockPaperScissorsLizardSpock.Application.Dtos;

namespace RockPaperScissorsLizardSpock.Application.Interfaces.Services
{
    public interface IGameResultService
    {
        Task<GameResultDto> PlayGameWithComputer(int playerChoiceId);

    }
}
