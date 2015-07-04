using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXSchool.Bll;
using WXSchool.Bll.Sys;
using WXSchool.Model;

namespace WXSchool.Site.PC.Controllers
{
    public class WXConfigController : BaseController<SysAccessTokenBiz>
    {
        public ActionResult Index()
        {
            var list = _biz.GetAccessTokens(string.Empty);
            return View(list);
        }

        public ActionResult Edit(int orgId=0)
        {
            var model = new SysAccessToken();
            if (orgId>0)
            {
                //model=
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SysAccessToken token)
        {
            token.OrgId = 1;//测试
            OperationResult result = _biz.AddAccessToken(token);

            return Json(result);
        }
    }
}
