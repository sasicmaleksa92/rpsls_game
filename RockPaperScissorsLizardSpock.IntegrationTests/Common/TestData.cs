using RockPaperScissorsLizardSpock.Domain.Entities;

namespace RockPaperScissorsLizardSpock.IntegrationTests.Common
{
    public class TestData
    {
        public const string AuthEndpoint = "api/accounts";
        public const string GameControllerEndpoint = "api/game";

        public const string TestUserUsername = "test";
        public const string TestUserPassword = "JelenaVanja3355!";

        public static List<string> GameChoices = ["Rock", "Paper", "Scissors", "Lizard", "Spock"];

        public static List<GameChoice> GameChoicesTestList = new List<GameChoice>();
    }
}
