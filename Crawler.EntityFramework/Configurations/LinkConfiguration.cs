using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Crawler.Data;

namespace Crawler.EntityFramework.Configurations
{
    public class LinksConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder
                .Property(w => w.Url)
                .HasMaxLength(1024);
            builder
                .HasKey(w => w.Id);
        }
    }
    
}
