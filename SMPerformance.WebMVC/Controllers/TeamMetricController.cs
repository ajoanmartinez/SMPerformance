using SMPerformance.Models;
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
            var model = new TeamMetricListItem[0];
            return View(model);
        }
    }
}