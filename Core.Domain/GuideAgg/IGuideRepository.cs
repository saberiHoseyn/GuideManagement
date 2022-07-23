using Framework.Domain;
using Framework.Dtos;
using System.Collections.Generic;

namespace GM.Core.Domain.GuideAgg
{
    public interface IGuideRepository : IRepository<long, Guide>
    {
        List<GuideDto> GetGuideDtos();
        GuideDto GetGuideDto(long id);
    }
}
