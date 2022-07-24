using Framework.Application;
using GM.Core.Application.Contracts.GuideAgg;
using GM.Core.Domain.GuideAgg;
using System.Collections.Generic;

namespace GM.Core.Application.Concretes
{
    public class GuideApplication : IGuideApplication
    {
        private readonly IGuideRepository guideRepository;

        public GuideApplication(IGuideRepository guideRepository)
        {
            this.guideRepository = guideRepository;
        }

        public OperationResult Create(CreatGuideModel command)
        {
            var operation = new OperationResult();
            if (guideRepository.Exists(x => x.Title == command.Title && x.GuideCategoryId == command.GuideCategoryId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var guide = new Guide(command.Title, command.Content, command.GuideCategoryId);
            guideRepository.Create(guide);
            guideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditGuideModel command)
        {
            var operation = new OperationResult();
            var guide = guideRepository.Get(command.Id);

            if (guide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (guideRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            guide.Edit(command.Title, command.Content, command.GuideCategoryId);
            guideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var guide = guideRepository.Get(id);

            if (guide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            guideRepository.Delete(guide);
            guideRepository.SaveChanges();
            return operation.Succedded();
        }

        public GuideVm GetDetaile(long id)
        {
            var guide = guideRepository.GetGuideDto(id);
            return new GuideVm
            {
                Id = guide.Id,
                Title = guide.Title,
                Content = guide.Content,
                GuideCategoryId = guide.GuideCategoryId,
                CategoryName = guide.GuideCategoryName,
                CreationDate = guide.CreationDate.ToFarsi(),
                IsRemoved = guide.IsRemoved
            };
        }

        public List<GuideVm> GetGuides()
        {
            var guides = guideRepository.GetGuideDtos();
            List<GuideVm> guideVms = new List<GuideVm>();

            guides.ForEach(guide => guideVms.Add(new GuideVm
            {
                Id = guide.Id,
                Title = guide.Title,
                Content = guide.Content,
                CategoryName = guide.GuideCategoryName,
                CreationDate = guide.CreationDate.ToFarsi(),
                GuideCategoryId = guide.GuideCategoryId,
                IsRemoved = guide.IsRemoved
            }));

            return guideVms;
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var guide = guideRepository.Get(id);

            if (guide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            guide.Remove();
            guideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restor(long id)
        {
            var operation = new OperationResult();
            var guide = guideRepository.Get(id);

            if (guide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            guide.Restor();
            guideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult IsExisted(long id)
        {
            var operetion = new OperationResult();
            if (!guideRepository.Exists(c => c.Id == id))
                return operetion.Failed(ApplicationMessages.RecordNotFound);
            else
                return operetion.Succedded();
        }

        public OperationResult ToggleStatus(long id)
        {
            var operation = new OperationResult();
            var guide = guideRepository.Get(id);

            if (guide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (guide.IsRemoved)
            {
                guide.Restor();
                guideRepository.SaveChanges();
                operation.Succedded(ApplicationMessages.RecordActivated);
            }
            else
            {
                guide.Remove();
                guideRepository.SaveChanges();
                operation.Succedded(ApplicationMessages.RecordDeactivated);
            }

            return operation;
        }
    }
}
