using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXSchool.Bll;
using WXSchool.Bll.Stu;

namespace WXSchool.Site.Mobile.Controllers
{
    public class StudentController : BaseController<StudentBiz>
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bind(string name, string idCard, string mobile)
        {
            string openId = "2121";//CurrentUser.OpenId;
            if (string.IsNullOrWhiteSpace(openId))
            {
                return Json(new OperationResult(OperationResultType.Error, "获取微信信息失败"));
            }

            OperationResult result = _biz.Bind(name, idCard, mobile, openId);
            return Json(result);
        }
    }
}
