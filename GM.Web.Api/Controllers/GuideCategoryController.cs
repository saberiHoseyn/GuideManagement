using GM.Core.Application.Contracts.GuideCategoryAgg;
using GM.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace GM.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideCategoryController : ControllerBase
    {
        private readonly IGuideCategoryApplication guideCategoryApplication;

        public GuideCategoryController(IGuideCategoryApplication guideCategoryApplication)
        {
            this.guideCategoryApplication = guideCategoryApplication;
        }

        // GET: api/<GuideCategoryController>
        [HttpGet]
        public IEnumerable<GuideCategoryVm> GetGuideCategoris()
        {
            return guideCategoryApplication.GetGuideCategories();
        }

        // GET api/<GuideCategoryController>/5
        [HttpGet("{id}")]
        public GuideCategoryDetailModelApi GetGuideCategory(long id)
        {
            return GetGuideCategoryDetailModelApi(id);
        }


        private GuideCategoryDetailModelApi GetGuideCategoryDetailModelApi(long id)
        {
            var category = new GuideCategoryDetailModelApi();
            var operation = guideCategoryApplication.IsExisted(id);


            if (!operation.IsSuccedded)
            {
                category.Failed(operation.Message);
                return category;
            }
            var c = guideCategoryApplication.GetDetaile(id);
            category.Succedded(c.Id, c.Name);
            return category;
        }

        #region ##
        //// POST api/<GuideCategoryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<GuideCategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GuideCategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion
    }
}
