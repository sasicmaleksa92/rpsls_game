using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RockPaperScissorsLizardSpock.Domain.Entities;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.Identity;

namespace RockPaperScissorsLizardSpock.Infrastructure.Persistance.DbContext
{
    public class GameDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<GameChoice> GameChoices { get; set; }
        public DbSet<GameResult> GameResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameDbContext).Assembly);

        }

    }
}