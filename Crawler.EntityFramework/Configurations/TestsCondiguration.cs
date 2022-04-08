using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Crawler.Data;

namespace Crawler.EntityFramework.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
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
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasKey(w => w.Id);
        }

    }
}
