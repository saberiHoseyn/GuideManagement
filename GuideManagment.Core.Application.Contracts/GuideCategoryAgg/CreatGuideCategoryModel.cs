using Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace GM.Core.Application.Contracts.GuideCategoryAgg
{
    public class CreatGuideCategoryModel
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
    }
}