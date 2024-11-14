using RockPaperScissorsLizardSpock.Application.Interfaces;
using RockPaperScissorsLizardSpock.Domain.Helpers;

namespace RockPaperScissorsLizardSpock.Infrastructure.Services
{
    public class RandomNumberGameAdapter : IRandomNumberGameAdapter
    {
        public int AdaptRange(int randomNumber)
        {
            return RangeNumberHelper.MapRange(randomNumber);
        }
    }

}
