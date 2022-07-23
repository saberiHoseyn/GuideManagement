using GM.Core.Domain.GuideAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Infrastructure.EFCore.Mapping
{
    public class GuideMapping : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.ToTable("Guides");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(10000).IsRequired();
            builder.Property(x => x.IsRemoved);

            builder.HasOne(x => x.GuideCategory)
                .WithMany(x => x.Guides)
                .HasForeignKey(x => x.GuideCategoryId);
        }
    }
}
