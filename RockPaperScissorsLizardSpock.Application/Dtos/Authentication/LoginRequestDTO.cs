using Destructurama.Attributed;
using System.ComponentModel.DataAnnotations;

namespace RockPaperScissorsLizardSpock.Application.Dtos.Authentication
{
    public class LoginRequestDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [NotLogged]
        public string Password { get; set; }
    }
}