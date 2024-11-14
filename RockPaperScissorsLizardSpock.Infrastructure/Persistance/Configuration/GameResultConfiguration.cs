using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissorsLizardSpock.Domain.Entities;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.Identity;

namespace RockPaperScissorsLizardSpock.Infrastructure.Persistance.Configuration
{
    public class GameResultConfiguration : IEntityTypeConfiguration<GameResult>
    {
        public void Configure(EntityTypeBuilder<GameResult> builder)
        {
            builder.ToTable("GameResult", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Result)
                .IsRequired();

            builder.Property(e => e.PlayedAt);

            builder.HasOne(gr => gr.PlayerChoice)
                .WithMany(gc => gc.PlayerResults)
                .HasForeignKey(gr => gr.PlayerChoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(gr => gr.ComputerChoice)
                .WithMany(gc => gc.ComputerResults)
                .HasForeignKey(gr => gr.ComputerChoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.PlayerChoiceId)
                .IsRequired();

            builder.Property(e => e.ComputerChoiceId)
                .IsRequired();

            builder.HasOne(typeof(ApplicationUser), nameof(GameResult.GamePlayer))
                .WithMany()
                .HasForeignKey(nameof(GameResult.PlayerId))
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
