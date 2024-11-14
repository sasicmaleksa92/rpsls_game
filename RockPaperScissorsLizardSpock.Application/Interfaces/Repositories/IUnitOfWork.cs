namespace RockPaperScissorsLizardSpock.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IGameChoiceRepository GameChoiceRepository { get; }

        IGameResultRepository GameResultRepository { get; }
    }
}
