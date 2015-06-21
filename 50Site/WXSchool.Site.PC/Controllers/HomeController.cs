using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXSchool.Bll.Sys;

namespace WXSchool.Site.PC.Controllers
{
    public class HomeController : BaseController<SysUserBiz>
    {
        //[Auth(0)]
        public ActionResult Index()
        {
            //if (CurrentUser.RoleType == 90)
            //{
            //}

            return RedirectToAction("Index", "School");
        }

    }
}
