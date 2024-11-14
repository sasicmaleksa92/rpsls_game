namespace RockPaperScissorsLizardSpock.Application.UseCases.Commons
{
    public class BaseError
    {
        public string? PropertyMessage { get; set; }
        public string? Code { get; set; }
        public string? ErrorMessage { get; set; }

        public string? InnerErrorMessage { get; set; }
    }
}
