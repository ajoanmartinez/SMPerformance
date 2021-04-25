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
    public class TeamMetricController : Controller
    {
        // GET: TeamMetric
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamMetricService(userId);
            var model = service.GetTeamMetrics();
            return View(model);
        }

        // GET: TeamMetric/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TeamMetric/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamMetricCreate model)
        {
            if (!ModelState.IsValid) return View(model);
          
            var service = CreateTeamMetricService();

            if (service.CreateTeamMetric(model))
            {
                TempData["SaveResult"] = "Your evaluation was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your evaluation coudl not be created.");

            return View(model);
        }

        private TeamMetricService CreateTeamMetricService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamMetricService(userId);
            return service;
        }
    }
}