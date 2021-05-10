using Microsoft.AspNet.Identity;
using SMPerformance.Data;
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

        // Get: TeamMetrics/ScrumMaster{id}
        public ActionResult ScrumMasterIndex(int scrumMasterId)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamMetricService(userId);
            var model = service.GetTeamMetricsByScrumMaster(scrumMasterId);
            return View(model);
        }

        // Get: TeamMetrics/Team{id}
        public ActionResult ScrumTeamIndex(int teamId)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamMetricService(userId);
            var model = service.GetTeamMetricsByScrumTeam(teamId);
            return View(model);
        }

        // GET: TeamMetric/Create
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScrumTeamService(userId);
            var service2 = new ScrumMasterService(userId);
           
            List<ScrumTeam> scrumTeams = service.GetScrumTeamList().ToList();

            var query = from c in scrumTeams
                        select new SelectListItem()
                        {
                            Value = c.TeamId.ToString(),
                            Text = c.TeamName
                        };

            List<ScrumMaster> scrumMasters = service2.GetScrumMasterList().ToList();

            var query2 = from c in scrumMasters
                        select new SelectListItem()
                        {
                            Value = c.ScrumMasterId.ToString(),
                            Text = c.FirstName+c.LastName
                        };

            ViewBag.TeamId = query;
            ViewBag.ScrumMasterId = query2;
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

        // GET: TeamMetric/Details
        public ActionResult Details(int id)
        {
            var svc = CreateTeamMetricService();
            var model = svc.GetTeamMetricById(id);

            return View(model);
        }

        // GET: TeamMetric/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateTeamMetricService();
            var detail = service.GetTeamMetricById(id);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service2 = new ScrumTeamService(userId);
            var service3 = new ScrumMasterService(userId);

            List<ScrumTeam> scrumTeams = service2.GetScrumTeamList().ToList();

            var query = from c in scrumTeams
                        select new SelectListItem()
                        {
                            Value = c.TeamId.ToString(),
                            Text = c.TeamName
                        };

            List<ScrumMaster> scrumMasters = service3.GetScrumMasterList().ToList();

            var query2 = from c in scrumMasters
                         select new SelectListItem()
                         {
                             Value = c.ScrumMasterId.ToString(),
                             Text = c.FirstName + c.LastName
                         };

            
            var model =
                new TeamMetricEdit
                {
                    EvalId = detail.EvalId,
                    TeamId = detail.TeamId,
                    ScrumMasterId = detail.ScrumMasterId,
                    Fiscalyear = detail.Fiscalyear,
                    FiscalQuarter = detail.FiscalQuarter,
                    Velocity = detail.Velocity,
                    BurnUp = detail.BurnUp,
                    ProdSupport = detail.ProdSupport,
                    CustomerRating = detail.CustomerRating,
                    RatingOfPerformance = detail.RatingOfPerformance
                };

            ViewBag.TeamId = query;
            ViewBag.ScrumMasterId = query2;

            return View(model);
        }

        // POST: Teammetric/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeamMetricEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.EvalId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTeamMetricService();

            if (service.UpdateTeamMetric(model))
            {
                TempData["SaveResult"] = "Your evaluation was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your evaluation could not be updated.");
            return View(model);
        }

        // GET: TeamMetric/Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateTeamMetricService();
            var model = svc.GetTeamMetricById(id);

            return View(model);
        }

        // POST: TeamMetric/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTeamMetricService();

            service.DeleteTeamMetric(id);

            TempData["SaveResult"] = "Your evaluation was deleted.";

            return RedirectToAction("Index");
        }


        private TeamMetricService CreateTeamMetricService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamMetricService(userId);
            return service;
        }
    }
}