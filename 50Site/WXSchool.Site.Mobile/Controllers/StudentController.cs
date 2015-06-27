using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QJZ.Framework.Utility;
using TCBase.Saker.Core;
using WeiXin.Bll;
using WXSchool.Bll;
using WXSchool.Bll.Stu;
using WXSchool.Bll.Sys;
using WXSchool.Model;

namespace WXSchool.Site.Mobile.Controllers
{
    public class StudentController : BaseController<StudentBiz>
    {
        private const string CookieKeyAppId = "WXSchool.Cookie.AppId";
        private const string CookieKeyAppSecret = "WXSchool.Cookie.AppSecret";

        public ActionResult Index(int orgId=0)
        {
            if (orgId == 0)
            {
                return Content("地址未配置机构OrgId");
            }
            if (string.IsNullOrWhiteSpace(CurrentUser.OpenId))
            {
                var biz = ClassFactory.GetInstance<SysAccessTokenBiz>();
                SysAccessToken token = biz.GetAccessToken(orgId);
                if (token==null)
                {
                    return Content("机构微信信息未配置");
                }

                var cookie = new HttpCookie(CookieKeyAppId, token.AppID);
                cookie.Expires = DateTime.Now.AddDays(15);
                Cookie.Save(cookie);
                var cookie2 = new HttpCookie(CookieKeyAppSecret, token.AppSecret);
                cookie2.Expires = DateTime.Now.AddDays(15);
                Cookie.Save(cookie2);

                string url = string.Format(AuthorizeUrl.GetOauth2BaseUrl(), Request.Url.ToString(), token.AppID);
                return Redirect(url);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Bind(string name, string idCard, string mobile)
        {
            string openId = CurrentUser.OpenId;
            if (string.IsNullOrWhiteSpace(openId))
            {
                return Json(new OperationResult(OperationResultType.Error, "获取微信信息失败"));
            }

            OperationResult result = _biz.Bind(name, idCard, mobile, openId);
            return Json(result);
        }
    }
}
