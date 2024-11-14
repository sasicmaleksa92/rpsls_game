using RockPaperScissorsLizardSpock.Application.Interfaces.Repositories;
using RockPaperScissorsLizardSpock.Domain.Entities;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.DbContext;

namespace RockPaperScissorsLizardSpock.Infrastructure.Persistance.Repository
{
    public class GameChoiceRepository(GameDbContext dbContext) : GenericRepository<GameChoice>(dbContext), IGameChoiceRepository
    {
    }


}
