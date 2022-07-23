using Framework.Infrastructure;
using GM.Core.Domain.GuideCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GM.Infrastructure.EFCore.Repository
{
    public class GuideCategoryRepository : RepositoryBase<long, GuideCategory>, IGuideCategoryRepository
    {
        private readonly GMContext Context;
        public GuideCategoryRepository(GMContext context) : base(context)
        {
            Context = context;
        }

        public GuideCategory GetGuideCategory(long id)
        {

            return Context.GuideCategories.Include(x => x.Guides).FirstOrDefault(x => x.Id == id);
        }

        public List<GuideCategory> GetGuideCategories()
        {
            return Context.GuideCategories.ToList();
        }
    }
}
