namespace RockPaperScissorsLizardSpock.Domain.Entities
{
    public class GameChoice
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GameResult> PlayerResults { get; set; } = new List<GameResult>();

        public ICollection<GameResult> ComputerResults { get; set; } = new List<GameResult>();

    }
}
