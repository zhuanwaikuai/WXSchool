using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXSchool.Bll;
using WXSchool.Bll.Stu;
using WXSchool.Model;

namespace WXSchool.Site.PC.Controllers
{
    public class StudentController : BaseController<StudentBiz>
    {
        public ActionResult Index()
        {
            var list = _biz.GetStudentList(string.Empty);
            return View(list);
        }

    }
}
