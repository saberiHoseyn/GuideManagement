using GM.Core.Application.Concretes;
using GM.Core.Application.Contracts.GuideAgg;
using GM.Core.Application.Contracts.GuideCategoryAgg;
using GM.Core.Domain.GuideAgg;
using GM.Core.Domain.GuideCategoryAgg;
using GM.Infrastructure.EFCore;
using GM.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace GM.Configor
{
    public class GuideManagmentBootstarpper
    {
        public static void Configur(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IGuideRepository, GuideRepository>();
            services.AddTransient<IGuideApplication, GuideApplication>();

            services.AddTransient<IGuideCategoryRepository, GuideCategoryRepository>();
            services.AddTransient<IGuideCategoryApplication, GuideCategoryApplication>();

            services.AddDbContext<GMContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
