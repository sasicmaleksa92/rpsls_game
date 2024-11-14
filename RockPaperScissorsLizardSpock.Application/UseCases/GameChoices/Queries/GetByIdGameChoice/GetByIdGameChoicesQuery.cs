using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameChoices.Queries.GetByIdGameChoice
{
    public class GetByIdGameChoicesQuery : IRequest<GameChoiceDto>
    {
        public int Id { get; set; }
    }
}
