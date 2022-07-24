using Framework.Application;
using GM.Core.Application.Contracts.GuideCategoryAgg;
using GM.Core.Domain.GuideCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace GM.Core.Application.Concretes
{
    public class GuideCategoryApplication : IGuideCategoryApplication
    {
        private readonly IGuideCategoryRepository guideCategoryRepository;

        public GuideCategoryApplication(IGuideCategoryRepository guideCategoryRepository)
        {
            this.guideCategoryRepository = guideCategoryRepository;
        }

        public OperationResult Create(CreatGuideCategoryModel command)
        {
            var operation = new OperationResult();
            if (guideCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var guideCategory = new GuideCategory(command.Name);
            guideCategoryRepository.Create(guideCategory);
            guideCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var guide = guideCategoryRepository.GetGuideCategory(id);

            if (guide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (guide.Guides.Count > 0)
                return operation.Failed("تعدادی از راهنماهای شما در این گروه ثبت شده اند!\n  ابتدا از پنل مدیریت راهنما گروه راهنما های خود را اصلاح کنید.");

            guideCategoryRepository.Delete(guide);
            guideCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditGuideCategoryModel command)
        {
            var operation = new OperationResult();
            var Category = guideCategoryRepository.Get(command.Id);

            if (Category == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (guideCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            Category.Edit(command.Name);
            guideCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditGuideCategoryModel GetDetaile(long id)
        {
            var category = guideCategoryRepository.GetGuideCategory(id);
            return new EditGuideCategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                
            };
        }

        public List<GuideCategoryVm> GetGuideCategories()
        {
            var categores = guideCategoryRepository.GetGuideCategories();
            return categores.Select(x => new GuideCategoryVm
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved
            }).ToList();
        }

        public OperationResult IsActivate(long id)
        {
            var operetion = new OperationResult();
            var guide = guideCategoryRepository.Get(id);
            if(guide.IsRemoved)
                return operetion.Failed(ApplicationMessages.RecordActivated);
            else
                return operetion.Succedded(ApplicationMessages.RecordDeactivated);
        }

        public OperationResult IsExisted(long id)
        {
            var operetion = new OperationResult();
            if (!guideCategoryRepository.Exists(c => c.Id == id))
                return operetion.Failed(ApplicationMessages.RecordNotFound);
            return operetion.Succedded();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var Category = guideCategoryRepository.Get(id);

            if (Category == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            Category.Remove();
            guideCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restor(long id)
        {
            var operation = new OperationResult();
            var Category = guideCategoryRepository.Get(id);

            if (Category == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            Category.Restor();
            guideCategoryRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}
