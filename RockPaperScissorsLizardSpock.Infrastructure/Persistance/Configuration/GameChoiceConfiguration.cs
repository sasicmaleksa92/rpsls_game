using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissorsLizardSpock.Domain.Entities;

namespace RockPaperScissorsLizardSpock.Infrastructure.Persistance.Configuration
{
    public class GameChoiceConfiguration : IEntityTypeConfiguration<GameChoice>
    {
        public void Configure(EntityTypeBuilder<GameChoice> builder)
        {
            builder.ToTable("GameChoice", "dbo");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasData(
                new GameChoice { Id = 1, Name = "Rock" },
                new GameChoice { Id = 2, Name = "Paper" },
                new GameChoice { Id = 3, Name = "Scissors" },
                new GameChoice { Id = 4, Name = "Lizard" },
                new GameChoice { Id = 5, Name = "Spock" });
                                                        
        }
    }
}
