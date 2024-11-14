namespace RockPaperScissorsLizardSpock.Application.Exceptions
{
    public class ExternalServiceException : Exception
    {
        public ExternalServiceException() : base()
        {

        }

        public ExternalServiceException(string message) : base(message)
        {

        }

        public ExternalServiceException(string message, Exception exp) : base(message, exp)
        {

        }
    }
}
