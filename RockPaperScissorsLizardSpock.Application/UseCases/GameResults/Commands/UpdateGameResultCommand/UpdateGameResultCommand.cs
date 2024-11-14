using MediatR;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Commands.UpdateGameResultCommand
{
    public class UpdateGameResultCommand : IRequest<bool>
    {
        public int PlayerId { get; set; }

        public bool IncludeInScore { get; set; }
    }
}
