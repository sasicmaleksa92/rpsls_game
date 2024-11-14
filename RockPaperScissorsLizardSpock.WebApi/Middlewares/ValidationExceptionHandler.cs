using Microsoft.AspNetCore.Diagnostics;
using RockPaperScissorsLizardSpock.Application.Exceptions;
using RockPaperScissorsLizardSpock.Application.UseCases.Commons;

namespace RockPaperScissorsLizardSpock.Common.Middlewares
{
    public sealed class ValidationExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ValidationExceptionHandler> _logger;

        public ValidationExceptionHandler(ILogger<ValidationExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not ValidationExceptionCustom validationException)
            {
                return false;
            }

            _logger.LogError(
                exception, "Exception occurred: {Message}", validationException.Message);


            await httpContext.Response
                .WriteAsJsonAsync(new BaseResponse<object> { Message = exception.Message ?? "Validation Errors", Errors = validationException.Errors }, cancellationToken);

            return true;
        }
    }
}
