using GM.Core.Domain.GuideAgg;
using GM.Core.Domain.GuideCategoryAgg;
using GM.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GM.Infrastructure.EFCore
{
    public class GMContext : DbContext
    {
        public DbSet<GuideCategory> GuideCategories { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public GMContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(GuideMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
