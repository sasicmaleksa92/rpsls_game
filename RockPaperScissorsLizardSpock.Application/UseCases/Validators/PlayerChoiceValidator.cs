using FluentValidation;
using RockPaperScissorsLizardSpock.Application.Dtos;

namespace RockPaperScissorsLizardSpock.Application.UseCases.Validators
{
    public class PlayerChoiceValidator : AbstractValidator<PlayerChoiceDto>
    {
        public PlayerChoiceValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty().WithMessage("Player choice is required")
                .InclusiveBetween(1, 5).WithMessage("Player choice must be between 1 and 5");

        }
    }

}
