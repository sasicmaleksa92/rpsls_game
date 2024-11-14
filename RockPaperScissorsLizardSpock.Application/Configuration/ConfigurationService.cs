using Microsoft.Extensions.Configuration;

namespace RockPaperScissorsLizardSpock.Application.Configuration
{
    public class ConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
            RandomNumberExternalSystemUrl = _configuration.GetSection("AppSettings").GetValue<string>("RandomNumberClientUrl")!;
        }

        public string RandomNumberExternalSystemUrl { get; set; }
    }

}
