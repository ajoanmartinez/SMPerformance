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
    public class ScrumTeamController : Controller
    {
        // GET: ScrumTeam
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScrumTeamService(userId);
            var model = service.GetScrumTeams();

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
        public ActionResult Create(ScrumTeamCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateScrumTeamService();

            if (service.CreateScrumTeam(model))
            {
                TempData["SaveResult"] = "Your team was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Team could not be created.");

            return View(model);

        }

        // GET: ScrumTeam/id
        public ActionResult Details(int id)
        {
            var svc = CreateScrumTeamService();
            var model = svc.GetScrumTeamById(id);

            return View(model);
        }

        private ScrumTeamService CreateScrumTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScrumTeamService(userId);
            return service;
        }
    }
}