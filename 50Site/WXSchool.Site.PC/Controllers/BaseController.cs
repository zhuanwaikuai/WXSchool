using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json;
using QJZ.Framework.Utility;
using TCBase.Saker.Core;
using WXSchool.ViewModel;

namespace WXSchool.Site.PC.Controllers
{
    public class BaseController<TBiz> : Controller where TBiz : TCBase.Saker.Core.Services.Service
    {
        /// <summary>
        /// 业务逻辑
        /// </summary>
        public TBiz _biz;

        /// <summary>
        /// 当前用户
        /// </summary>
        public CurrentUserVM CurrentUser
        {
            get
            {
                var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName]; //获取cookie 
                if (authCookie == null)
                {
                    return null;
                }
                var ticket = FormsAuthentication.Decrypt(authCookie.Value); //解密
                return JsonConvert.DeserializeObject<CurrentUserVM>(ticket.UserData);
            }
        }

        public int PageSize { get { return 10; } }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            //类工厂、注入
            _biz = ClassFactory.GetInstance<TBiz>();

            if (CurrentUser != null)
            {
                ViewBag.RoleType = CurrentUser.RoleType;
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            var ex = filterContext.Exception;
            Log4Helper.Write(ex.ToString(), LogMessageType.Error);
        }
    }
}
