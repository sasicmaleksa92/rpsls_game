namespace RockPaperScissorsLizardSpock.Application.Interfaces
{
    public interface IRandomNumberService
    {
        Task<int> GetRandomNumberAsync();
    }
}
