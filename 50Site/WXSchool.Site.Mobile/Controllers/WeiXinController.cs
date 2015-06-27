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

            string appId = Cookie.GetValue(CookieKeyAppId);
            string appSecret = Cookie.GetValue(CookieKeyAppSecret);
            if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(appSecret))
            {
                return Content("读取相关cookie失败");
            }
            string openId = WeiXinBiz.GetOpenId(code,appId,appSecret);
            if (!string.IsNullOrWhiteSpace(openId))
            {
                var cookie = new HttpCookie(CookieKeyOpenId, openId);
                cookie.Expires = DateTime.Now.AddDays(15);
                Cookie.Save(cookie);

                return Redirect(reurl);
            }

            return Content("获取OpenId失败");
        }
    }
}
