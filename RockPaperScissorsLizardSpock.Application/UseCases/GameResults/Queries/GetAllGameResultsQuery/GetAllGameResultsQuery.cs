using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Queries.GetAllGameResultsQuery
{
    public class GetAllGameResultsQuery : IRequest<List<GameResultDto>>
    {
    }
}
