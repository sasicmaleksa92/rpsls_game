using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RockPaperScissorsLizardSpock.Domain.Entities;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.DbContext;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.Identity;

namespace RockPaperScissorsLizardSpock.IntegrationTests.Common
{
    public class DataSeedService : IDataSeedService
    {
        private readonly GameDbContext _context;
        IPasswordHasher<ApplicationUser> _passwordHasher;

        public DataSeedService(GameDbContext context, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task SeedDataAsync()
        {
            await SeedGameChoicesAsync();
            await SeedUserAsync();
            await _context.SaveChangesAsync();
        }

        public async Task SeedGameChoicesAsync()
        {
            if (!await _context.GameChoices.AnyAsync())
            {
                _context.GameChoices.AddRange(TestData.GameChoices.Select(x => new GameChoice
                {
                    Name = x
                }));
            }
        }

        public async Task SeedUserAsync()
        {
            var user = new ApplicationUser
            {
                UserName = TestData.TestUserUsername
            };
           
            if (!await _context.Users.AnyAsync())
            {
                _context.Users.Add(user);
            }

            user.PasswordHash = _passwordHasher.HashPassword(user, TestData.TestUserPassword);
        }
    }
}
