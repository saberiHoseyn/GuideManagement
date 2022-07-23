using GM.Core.Application.Contracts.GuideCategoryAgg;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    public class GuideCategoryController : Controller
    {
        private readonly IGuideCategoryApplication guideCategoryApplication;

        public GuideCategoryController(IGuideCategoryApplication guideCategoryApplication)
        {
            this.guideCategoryApplication = guideCategoryApplication;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var model = guideCategoryApplication.GetGuideCategories();

            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(CreatGuideCategoryModel command)
        {
            var result = guideCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var model = guideCategoryApplication.GetDetaile(id);

            return View(model);
        }

        [HttpPost]
        public JsonResult Edit(EditGuideCategoryModel command)
        {
            var result = guideCategoryApplication.Edit(command);

            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult Restor(long id)
        {
            var result = guideCategoryApplication.Restor(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(long id)
        {
            var result = guideCategoryApplication.Remove(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var model = guideCategoryApplication.GetDetaile(id);

            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(EditGuideCategoryModel command)
        {
            var result = guideCategoryApplication.Delete(command.Id);
            return new JsonResult(result);
        }

    }
}
