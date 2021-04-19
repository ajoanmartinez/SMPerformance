using SMPerformance.Models;
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
            var model = new ScrumMasterListItem[0];
            return View(model);
        }
    }
}