using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WXSchool.Site.PC.Controllers
{
    public class MeetingController : Controller
    {
        //
        // GET: /Meeting/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int mcid=0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {
            return Json(null);
        }
    }
}
