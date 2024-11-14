using Microsoft.Extensions.DependencyInjection;
using RockPaperScissorsLizardSpock.Application.Interfaces.Services;
using RockPaperScissorsLizardSpock.Application.Interfaces;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.DbContext;
using RockPaperScissorsLizardSpock.Infrastructure.Services.Game;
using RockPaperScissorsLizardSpock.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RockPaperScissorsLizardSpock.Application.Interfaces.Repositories;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.Repository;
using RockPaperScissorsLizardSpock.Application.Interfaces.AuthService;
using RockPaperScissorsLizardSpock.Infrastructure.Services.AuthService;
using Polly.Extensions.Http;
using Polly;

namespace RockPaperScissorsLizardSpock.Infrastructure.ServiceExtensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GameDbContext>(options =>
            {
                options.UseSqlServer(connectionString, o => o.MigrationsAssembly("RockPaperScissorsLizardSpock.Infrastructure"));
            });

            //Http client policy
            var randomNumberClientBaseUrl = configuration["AppSettings:RandomNumberClientUrl"];
            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
    .                           WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10));


            services.AddHttpClient<IRandomNumberService, RandomNumberService>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(randomNumberClientBaseUrl);
            })
            .AddPolicyHandler(retryPolicy)
            .AddPolicyHandler(timeoutPolicy);


            // DI services
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddTransient<IGameChoiceService, GameChoiceService>();
            services.AddTransient<IGameResultService, GameResultService>();
            services.AddTransient<IRandomNumberGameAdapter, RandomNumberGameAdapter>();
            services.AddScoped<IGameChoiceRepository, GameChoiceRepository>();
            services.AddScoped<IGameResultRepository, GameResultRepository>();

            return services;
        }
    }
}
