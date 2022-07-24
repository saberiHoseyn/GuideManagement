using Framework.Application;
using System.Collections.Generic;

namespace GM.Core.Application.Contracts.GuideCategoryAgg
{
    public interface IGuideCategoryApplication
    {
        OperationResult Create(CreatGuideCategoryModel command);
        OperationResult Edit(EditGuideCategoryModel command);
        OperationResult Remove(long id);
        OperationResult Restor(long id);
        OperationResult Delete(long id);
        OperationResult IsExisted(long id);
        OperationResult IsActivate(long id);
        List<GuideCategoryVm> GetGuideCategories();
        EditGuideCategoryModel GetDetaile(long id);
    }
}
