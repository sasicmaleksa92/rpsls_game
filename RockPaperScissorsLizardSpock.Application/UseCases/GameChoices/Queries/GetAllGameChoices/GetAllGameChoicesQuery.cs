using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameChoices.Queries.GetAllGameChoices
{
    public class GetAllGameChoicesQuery : IRequest<List<GameChoiceDto>>
    {
    }
}
