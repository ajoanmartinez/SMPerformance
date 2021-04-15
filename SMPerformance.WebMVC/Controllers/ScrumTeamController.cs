using SMPerformance.Models;
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
            var model = new ScrumTeamListItem[0];
            return View(model);
        }
    }
}