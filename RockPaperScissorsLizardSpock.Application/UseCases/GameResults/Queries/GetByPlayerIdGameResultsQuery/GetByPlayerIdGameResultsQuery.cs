using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Queries.GetByPlayerIdGameResultsQuery
{
    public class GetByPlayerIdGameResultsQuery : IRequest<List<GameResultDto>>
    {
        public int PlayerId { get; set; }
    }
}
