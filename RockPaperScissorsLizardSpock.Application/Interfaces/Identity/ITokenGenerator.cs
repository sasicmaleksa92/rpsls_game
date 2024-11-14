namespace RockPaperScissorsLizardSpock.Application.Interfaces.AuthService
{
    public interface ITokenGenerator
    {
        public string GenerateJWTToken((string userId, string userName, IList<string> roles) userDetails);
    }
}
