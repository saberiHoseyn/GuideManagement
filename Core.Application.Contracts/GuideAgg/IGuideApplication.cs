using Framework.Application;
using System.Collections.Generic;

namespace GM.Core.Application.Contracts.GuideAgg
{
    public interface IGuideApplication
    {
        OperationResult Create(CreatGuideModel command);
        OperationResult Edit(EditGuideModel command);
        OperationResult Remove(long id);
        OperationResult Restor(long id);
        OperationResult ToggleStatus(long id);
        OperationResult Delete(long id);
        OperationResult IsExisted(long id);
        List<GuideVm> GetGuides();
        GuideVm GetDetaile(long id);
    }
}
