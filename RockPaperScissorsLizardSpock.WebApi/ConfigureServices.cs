using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RockPaperScissorsLizardSpock.Application.Configuration;
using RockPaperScissorsLizardSpock.Application.Interfaces.AuthService;
using RockPaperScissorsLizardSpock.Common.Middlewares;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.DbContext;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.Identity;
using RockPaperScissorsLizardSpock.Infrastructure.Services.AuthService;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace RockPaperScissorsLizardSpock.WebApi
{
    public static class ConfigureServices
    {
        public static void AddInjections(this IServiceCollection services, IConfiguration configuration)
        {
            var _key = configuration["Jwt:Key"];
            var _issuer = configuration["Jwt:Issuer"];
            var _audience = configuration["Jwt:Audience"];
            var _expirtyMinutes = configuration["Jwt:ExpiryMinutes"];

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddExceptionHandler<ValidationExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddProblemDetails();
            services.AddScoped<ConfigurationService>();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<GameDbContext>()
                .AddDefaultTokenProviders();

            // Configuration for token
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = _audience,
                    ValidIssuer = _issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                    ClockSkew = TimeSpan.FromMinutes(Convert.ToDouble(_expirtyMinutes))

                };
                x.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        if (context.AuthenticateFailure != null)
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            context.HandleResponse();

                            var result = JsonConvert.SerializeObject(new { error = "Forbidden" });
                            return context.Response.WriteAsync(result);
                        }

                        return Task.CompletedTask;
                    }
                };

            });

            services.AddSingleton<ITokenGenerator>(new TokenGenerator(_key, _issuer, _audience, _expirtyMinutes));


        }
    }
}
