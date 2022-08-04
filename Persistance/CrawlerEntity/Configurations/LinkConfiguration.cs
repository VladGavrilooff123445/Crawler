using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.CrawlerEntity.Configurations
{
    public class LinksConfiguration : IEntityTypeConfiguration<Domain.Link>
    {
        public void Configure(EntityTypeBuilder<Domain.Link> builder)
        {
            builder
                .Property(w => w.Url)
                .HasMaxLength(1024);
            builder
                .HasKey(w => w.Id);
        }
    }
    
}
