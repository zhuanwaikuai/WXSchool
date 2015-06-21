using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using QJZ.Framework.Utility;
using WXSchool.Bll;
using WXSchool.Bll.Sys;
using WXSchool.Model.Sys;
using WXSchool.ViewModel;

namespace WXSchool.Site.PC.Controllers
{
    public class AccountController : BaseController<SysUserBiz>
    {
        /// <summary>
        /// 保存身份信息
        /// </summary>
        /// <param name="user"></param>
        private void Authentication(CurrentUserVM user)
        {
            string userData = JsonConvert.SerializeObject(user);
            var ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddHours(12), false, userData);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public JsonResult Login(string userName, string password)
        {
            OperationResult result = _biz.Login(userName, password);
            if (result.ResultType == OperationResultType.Success)
            {
                var user = result.AppendData as SysUser;
                
                var currentUser = new CurrentUserVM
                {
                    RoleType = user.RoleType,
                    UId = user.UId
                };
                Authentication(currentUser);
            }
            return Json(result);
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Cookie.Remove(FormsAuthentication.FormsCookieName);
            return RedirectToAction("Login");
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangePassword(string pwd, string newPwd)
        {
            OperationResult result = _biz.ChangePwd(CurrentUser.UId, pwd, newPwd);
            return Json(result);
        }
    }
}
