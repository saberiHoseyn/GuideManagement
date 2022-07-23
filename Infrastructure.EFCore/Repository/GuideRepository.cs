using Framework.Dtos;
using Framework.Infrastructure;
using GM.Core.Domain.GuideAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace GM.Infrastructure.EFCore.Repository
{
    public class GuideRepository : RepositoryBase<long, Guide>, IGuideRepository
    {
        private readonly GMContext Context;
        public GuideRepository(GMContext context) : base(context)
        {
            Context = context;
        }

        public GuideDto GetGuideDto(long id)
        {
            return Context.Guides.Include(x => x.GuideCategory).Select(x => new GuideDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreationDate = x.CreationDate,
                GuideCategoryId = x.GuideCategoryId,
                GuideCategoryName = x.GuideCategory.Name,
                IsRemoved = x.IsRemoved
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<GuideDto> GetGuideDtos()
        {
            return Context.Guides
                .Include(x => x.GuideCategory)
                .Select(x => new GuideDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreationDate = x.CreationDate,
                    GuideCategoryId = x.GuideCategoryId,
                    GuideCategoryName = x.GuideCategory.Name,
                    IsRemoved = x.IsRemoved
                }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
