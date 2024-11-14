using Microsoft.AspNetCore.Identity;
using RockPaperScissorsLizardSpock.Domain.Entities;
using RockPaperScissorsLizardSpock.Domain.Entities.Identity;

namespace RockPaperScissorsLizardSpock.Infrastructure.Persistance.Identity
{
    public class ApplicationUser : IdentityUser<int>, IGamePlayer
    {
        public string? FullName { get; set; }
        ICollection<GameResult> IGamePlayer.GameResults { get; set;}
    }
}
