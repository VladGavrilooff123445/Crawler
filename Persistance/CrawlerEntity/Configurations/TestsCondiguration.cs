using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.CrawlerEntity.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Domain.Test>
    {
        public void Configure(EntityTypeBuilder<Domain.Test> builder)
        {
            builder
                .Property(w => w.Url)
                .HasMaxLength(1024);
            builder
                .Property(w => w.Date)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");
            builder
                .HasMany(test => test.Links)
                .WithOne(link => link.Test)
                .HasForeignKey(link => link.TestId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasKey(w => w.Id);
        }
    }
}
