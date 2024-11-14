namespace RockPaperScissorsLizardSpock.Domain.Entities.Identity
{
    public interface IGamePlayer
    {
        int Id { get; set; }

        string UserName { get; set; }
        string? FullName { get; set; }

        ICollection<GameResult> GameResults { get; set; }
    }
}
