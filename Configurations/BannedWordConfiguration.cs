using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabu.Entities;

namespace Tabu.Configurations
{
    public class BannedWordConfiguration : IEntityTypeConfiguration<BannedWord>
    {
        public void Configure(EntityTypeBuilder<BannedWord> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Text)
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
