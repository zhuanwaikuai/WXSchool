using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QJZ.Framework.Utility;
using TCBase.Saker.Core;
using WXSchool.ViewModel;

namespace WXSchool.Site.Mobile.Controllers
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
        public CurrentUserVM CurrentUser;
        private const string CookieKeyOpenId = "WXSchool.Cookie.OpenId";

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            //类工厂、注入
            _biz = ClassFactory.GetInstance<TBiz>();

            CurrentUser = new CurrentUserVM
            {
                OpenId = "oPHmajv6OJYI67ihpr_OBfAHg9bs"//Cookie.GetValue(CookieKeyOpenId),
            };
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            var ex = filterContext.Exception;
            Log4Helper.Write(ex.ToString(), LogMessageType.Error);
        }
    }
}
