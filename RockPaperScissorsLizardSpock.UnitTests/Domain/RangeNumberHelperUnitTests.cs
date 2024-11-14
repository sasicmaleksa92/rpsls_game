namespace RockPaperScissorsLizardSpock.UnitTests.Domain
{
    using RockPaperScissorsLizardSpock.Domain.Helpers;
    using Xunit;
 
    public class RangeNumberHelperUnitTets
    {
        [Theory]
        [InlineData(1, 1, 100, 1, 5, 1)]  // 1 maps to 1
        [InlineData(30, 1, 100, 1, 5, 2)]  // 30 maps to 2
        [InlineData(50, 1, 100, 1, 5, 3)] // 50 maps to 3
        [InlineData(63, 1, 100, 1, 5, 4)] // 63 maps to 4
        [InlineData(71, 1, 100, 1, 5, 4)] // 71 maps to 4
        [InlineData(85, 1, 100, 1, 5, 5)] // 85 maps to 5
        [InlineData(99, 1, 100, 1, 5, 5)] // 99 maps to 5
        [InlineData(100, 1, 100, 1, 5, 5)] // 100 maps to 5
        [InlineData(10, 1, 20, 1, 5, 3)]  // 10 maps to 3
        [InlineData(7, 1, 20, 1, 5, 2)]   // 7 maps to 2
        public void MapRange_ShouldMapValueCorrectly(int x, int inputMin, int inputMax, int outputMin, int outputMax, int expected)
        {
            // Act
            var result = RangeNumberHelper.MapRange(x, inputMin, inputMax, outputMin, outputMax);

            // Assert
            Assert.Equal(expected, result);
        }
    }

}