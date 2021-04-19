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

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScrumMasterCreate model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }

    
}