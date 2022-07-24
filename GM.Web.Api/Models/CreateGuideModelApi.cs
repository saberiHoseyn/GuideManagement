using Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GM.Web.Api.Models
{
    public class CreateGuideModelApi
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Content { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Range(1, 1000, ErrorMessage = ValidationMessages.OutOfrange)]
        public long GuideCategoryId { get; set; }
    }
}
