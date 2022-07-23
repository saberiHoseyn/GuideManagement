using Framework.Domain;
using System.Collections.Generic;

namespace GM.Core.Domain.GuideCategoryAgg
{
    public interface IGuideCategoryRepository : IRepository<long, GuideCategory>
    {
        List<GuideCategory> GetGuideCategories();
        GuideCategory GetGuideCategory(long id);
    }
}
