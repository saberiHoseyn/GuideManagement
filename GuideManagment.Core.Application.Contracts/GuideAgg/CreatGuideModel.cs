using Framework.Application;
using GM.Core.Application.Contracts.GuideCategoryAgg;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Core.Application.Contracts.GuideAgg
{
    public class CreatGuideModel
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Content { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Range(1, 1000, ErrorMessage = ValidationMessages.OutOfrange)]
        public long GuideCategoryId { get; set; }

        public List<GuideCategoryVm> GuideCategories { get; set; } = new List<GuideCategoryVm>();
    }
}