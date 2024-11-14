using FluentValidation;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Commands.CreateGameResultCommand
{
    public class CreateGameResultCommandValidator : AbstractValidator<CreateGameResultCommand>
    {
        public CreateGameResultCommandValidator()
        {
            RuleFor(p => p.gameResultDto.Id)
                .NotNull().WithMessage("Id is required");


            RuleFor(p => p.gameResultDto.PlayerChoiceId)
                .NotNull()
                .InclusiveBetween(1, 5).WithMessage("Player choice must be between 1 and 5");

            RuleFor(p => p.gameResultDto.ComputerChoiceId)
                .NotNull()
                .InclusiveBetween(1, 5).WithMessage("Computer choice must be between 1 and 5");

            RuleFor(p => p.gameResultDto.PlayedAt)
                .NotNull();

        }
    }
}
