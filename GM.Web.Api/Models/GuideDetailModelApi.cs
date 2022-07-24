using GM.Core.Application.Contracts.GuideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM.Web.Api.Models
{
    public class GuideDetailModelApi : GuideVm
    {
        public bool IsExisted { get; set; } = false;
        public string Message { get; set; }

        public GuideDetailModelApi()
        {
        }

        public GuideDetailModelApi Failed(string message)
        {
            IsRemoved = false;
            Message = message;
            return this;
        }


        public GuideDetailModelApi Succedded( long? id,
            string title,
            string content,
            string creationDate,
            long? guideCategoryId,
            string categoryName,
            bool? isRemoved,
            string message = "عملیات با موفقیت انجام شد.")
        {
            IsExisted = true;
            Message = message;
            Id = id;
            Title = title;
            Content = content;
            CreationDate = creationDate;
            GuideCategoryId = guideCategoryId;
            CategoryName = categoryName;
            IsRemoved = isRemoved;
            return this;
        }
    }
}
