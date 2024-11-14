using Microsoft.AspNetCore.Identity;
using RockPaperScissorsLizardSpock.Application.UseCases.Commons;

namespace RockPaperScissorsLizardSpock.Application.Exceptions
{
    public class ValidationExceptionCustom : Exception
    {
        public IEnumerable<BaseError> Errors { get; }


        public ValidationExceptionCustom(string message): base(message)
        {
        }
        
        public ValidationExceptionCustom()
            : base("One or more validation failures have occured.")
        {
            Errors = new List<BaseError>();
        }

        public ValidationExceptionCustom(IEnumerable<IdentityError> errors) : this()
        {
            Errors = errors.Select(e => new BaseError
            {
                Code = e.Code,
                ErrorMessage = e.Description
            });
        }

        public ValidationExceptionCustom(IEnumerable<BaseError> errors)
            : this()
        {
            Errors = errors;
        }
    }
}
