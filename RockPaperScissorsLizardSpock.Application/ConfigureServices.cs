using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RockPaperScissorsLizardSpock.Application.Configuration;
using RockPaperScissorsLizardSpock.Application.UseCases.Commons.Behaviours;
using RockPaperScissorsLizardSpock.Application.UseCases.Validators;
using System.Reflection;

namespace RockPaperScissorsLizardSpock.Application
{
    public static class ConfigureServices
    {
        public static void AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining<PlayerChoiceValidator>();
            services.AddScoped<ConfigurationService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        }
    }
}
