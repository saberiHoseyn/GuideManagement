using GM.Core.Application.Contracts.GuideAgg;
using GM.Core.Application.Contracts.GuideCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceHost.Controllers
{
    public class GuideController : Controller
    {
        private readonly IGuideCategoryApplication guideCategoryApplication;
        private readonly IGuideApplication guideApplication;
        public GuideController(IGuideCategoryApplication guideCategoryApplication, IGuideApplication guideApplication)
        {
            this.guideCategoryApplication = guideCategoryApplication;
            this.guideApplication = guideApplication;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<GuideVm> model = guideApplication.GetGuides();
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreatGuideModel
            {
                GuideCategories = guideCategoryApplication.GetGuideCategories()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult Create(CreatGuideModel command)
        {
            var result = guideApplication.Create(command);
            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var guide = guideApplication.GetDetaile(id);
            var editModel = new EditGuideModel
            {
                Id = guide.Id,
                Title = guide.Title,
                Content = guide.Content,
                GuideCategoryId = guide.GuideCategoryId,
                GuideCategories = guideCategoryApplication.GetGuideCategories()
            };
            
            return View(editModel);
        }

        [HttpPost]
        public JsonResult Edit(EditGuideModel command)
        {
            var result = guideApplication.Edit(command);

            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult Restor(long id)
        {
            var result = guideApplication.Restor(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(long id)
        {
            var result = guideApplication.Remove(id);

            return RedirectToAction("Index", result);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var guide = guideApplication.GetDetaile(id);
            var editModel = new EditGuideModel { Id = guide.Id, Title = guide.Title };

            return View(editModel);
        }

        [HttpPost]
        public JsonResult Delete(EditGuideModel command)
        {
            var result = guideApplication.Delete(command.Id);
            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            var guide = guideApplication.GetDetaile(id);
            return View(guide);
        }

    }
}
