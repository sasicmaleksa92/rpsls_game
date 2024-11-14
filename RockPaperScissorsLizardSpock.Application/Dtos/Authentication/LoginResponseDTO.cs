namespace RockPaperScissorsLizardSpock.Application.Dtos.Authentication
{
    public class LoginResponseDTO
    {
        public string AccessToken { get; set; }
        public UserResponseDTO User { get; set; }
    }
}