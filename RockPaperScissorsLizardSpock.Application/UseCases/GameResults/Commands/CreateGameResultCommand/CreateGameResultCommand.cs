using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Commands.CreateGameResultCommand
{
    public record CreateGameResultCommand(GameResultDto gameResultDto) : IRequest<GameResultDto>;
}
