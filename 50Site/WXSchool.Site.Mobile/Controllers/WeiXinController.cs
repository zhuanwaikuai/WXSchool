using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QJZ.Framework.Utility;
using WeiXin.Bll;

namespace WXSchool.Site.Mobile.Controllers
{
    public class WeiXinController : Controller
    {
        private const string CookieKeyOpenId = "WXSchool.Cookie.OpenId";
        private const string CookieKeyAppId = "WXSchool.Cookie.AppId";
        private const string CookieKeyAppSecret = "WXSchool.Cookie.AppSecret";

        public ActionResult Oauth2Base(string code = "", int state = 0, string reurl = "")
        {
            if (string.IsNullOrEmpty(code))
            {
                //授权失败
                return Content("授权失败");
            }

            string openId = WeiXinBiz.GetOpenId(code);
            if (!string.IsNullOrWhiteSpace(openId))
            {
                HttpCookie cookie = new HttpCookie(CookieKeyOpenId, openId);
                cookie.Expires = DateTime.Now.AddMonths(1);
                Cookie.Save(cookie);

                return Redirect(reurl);
            }

            return Content("获取OpenId失败");
        }
    }
}
