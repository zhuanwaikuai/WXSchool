using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WXSchool.Site.PC.Controllers
{
    public class HomeController : Controller
    {
        [Auth(0)]
        public ActionResult Index()
        {
            return View();
        }

    }
}
