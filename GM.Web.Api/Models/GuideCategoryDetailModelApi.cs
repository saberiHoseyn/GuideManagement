using GM.Core.Application.Contracts.GuideCategoryAgg;

namespace GM.Web.Api.Models
{
    public class GuideCategoryDetailModelApi : GuideCategoryVm
    {
        public bool IsExisted { get; set; } = false;
        public string Message { get; set; }

        public GuideCategoryDetailModelApi()
        {
        }

        public GuideCategoryDetailModelApi Failed(string message)
        {
            IsRemoved = false;
            Message = message;
            return this;
        }


        public GuideCategoryDetailModelApi Succedded( long? id, string name, string message = "عملیات با موفقیت انجام شد.")
        {
            IsExisted = true;
            Message = message;
            Id = id;
            Name = name;
            return this;
        }
    }
}
