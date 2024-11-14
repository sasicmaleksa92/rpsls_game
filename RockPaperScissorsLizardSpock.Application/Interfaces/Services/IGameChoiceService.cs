using RockPaperScissorsLizardSpock.Application.Dtos;

namespace RockPaperScissorsLizardSpock.Application.Interfaces.Services
{
    public interface IGameChoiceService
    {
        Task<GameChoiceDto> GetRandomGameChoiceAsync();

    }
}
