namespace RockPaperScissorsLizardSpock.Application.Interfaces.AuthService
{
    public interface IIdentityService
    {
        Task<(bool isSucceed, int userId)> CreateUserAsync(string userName, string password);

        Task<bool> SigninUserAsync(string userName, string password);

        Task<string> GetCheckedUserIdAsync(string userName, string password);
    }
}
