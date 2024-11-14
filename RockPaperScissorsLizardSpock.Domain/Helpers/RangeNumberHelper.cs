namespace RockPaperScissorsLizardSpock.Domain.Helpers
{
    public class RangeNumberHelper
    {
        public static int MapRange(int x, int inputMin = 1, int inputMax = 100, int outputMin = 1, int outputMax = 5)
        {
            if (x < inputMin) x = inputMin;
            if (x > inputMax) x = inputMax;

            double intervalSize = (double)(inputMax - inputMin + 1) / (outputMax - outputMin + 1);
            int mappedValue = (int)((x - inputMin) / intervalSize) + outputMin;

            return mappedValue;
        }
    }
}

