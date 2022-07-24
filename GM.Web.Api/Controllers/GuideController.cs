using Framework.Application;
using GM.Core.Application.Contracts.GuideAgg;
using GM.Core.Application.Contracts.GuideCategoryAgg;
using GM.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace GM.Web.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly IGuideApplication guideApplication;
        private readonly IGuideCategoryApplication guideCategoryApplication;

        public GuideController(IGuideApplication guideApplication, IGuideCategoryApplication guideCategoryApplication)
        {
            this.guideApplication = guideApplication;
            this.guideCategoryApplication = guideCategoryApplication;
        }


        // GET: api/<GuideApiController>
        [HttpGet]
        public IEnumerable<GuideVm> GetGuides()
        {
            return guideApplication.GetGuides();
        }


        // GET api/<GuideApiController>/5
        [HttpGet("{id}")]
        public GuideDetailModelApi GetGuide(long id)
        {
            return GetGuideDetailModelApiFromGuideApplication(id);
        }


        // POST api/<GuideApiController>
        [HttpPost]
        public OperationResult PostGuide([FromBody] CreateGuideModelApi value)
        {
            return CreatNewGuide(value);
        }


        // DELETE api/<GuideApiController>/5
        [HttpDelete("{id}")]
        public OperationResult Delete(long id)
        {
            return JsonResultFromGuideApplicationForResultDelete(id);
        }


        // PUT api/<GuideApiController>/5
        [HttpPut("{id}")]
        public OperationResult Put(long id)
        {
            return guideApplication.ToggleStatus(id);
        }




        private GuideDetailModelApi GetGuideDetailModelApiFromGuideApplication(long id)
        {
            var guide = new GuideDetailModelApi();
            var operation = guideApplication.IsExisted(id);


            if (!operation.IsSuccedded)
            {
                guide.Failed(operation.Message);
                return guide;
            }
            var c = guideApplication.GetDetaile(id);
            guide.Succedded(c.Id,
                            c.Title,
                            c.Content,
                            c.CreationDate,
                            c.GuideCategoryId,
                            c.CategoryName,
                            c.IsRemoved);
            return guide;
        }
        private OperationResult JsonResultFromGuideApplicationForResultDelete(long id)
        {
            var operation = guideApplication.IsExisted(id);

            if (!operation.IsSuccedded)
                return operation;
            else
                operation = guideApplication.Delete(id);

            return operation;
        }
        private OperationResult CreatNewGuide(CreateGuideModelApi value)
        {
            var operation = guideCategoryApplication.IsExisted(value.GuideCategoryId); ;

            if (!operation.IsSuccedded)
            {
                return operation;
            }
            else
            {
                operation = guideCategoryApplication.IsActivate(value.GuideCategoryId);

                if (!operation.IsSuccedded)
                {
                    return operation;
                }
                else
                {
                    var guide = new CreatGuideModel
                    {
                        Title = value.Title,
                        Content = value.Content,
                        GuideCategoryId = value.GuideCategoryId
                    };
                    operation = guideApplication.Create(guide);
                }
            }
            return operation;
        }
    }
}
