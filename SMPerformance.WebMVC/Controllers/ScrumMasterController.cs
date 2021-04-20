using Microsoft.AspNet.Identity;
using SMPerformance.Models;
using SMPerformance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMPerformance.WebMVC.Controllers
{
    [Authorize]
    public class ScrumMasterController : Controller
    {
        // GET: ScrumMaster
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScrumMasterService(userId);
            var model = service.GetScrumMasters();

            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScrumMasterCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateScrumMasterService();

            if (service.CreateScrumMaster(model))
            {
                TempData["SaveResult"] = "Your scrum master was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Scrum master could not be created.");

            return View(model);
           
        }

        // GET: ScrumMaster/id
        public ActionResult Details(int id)
        {
            var svc = CreateScrumMasterService();
            var model = svc.GetScrumMasterById(id);

            return View(model);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateScrumMasterService();
            var detail = service.GetScrumMasterById(id);
            var model =
                new ScrumMasterEdit
                {
                    ScrumMasterId = detail.ScrumMasterId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName
                };
            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ScrumMasterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ScrumMasterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateScrumMasterService();

            if (service.UpdateScrumMaster(model))
            {
                TempData["SaveResult"] = "Your scrum master was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Scrum master could not be updated.");
            return View();
        }

        private ScrumMasterService CreateScrumMasterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScrumMasterService(userId);
            return service;
        }
    }    
}