using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using QJZ.Framework.Utility;
using WXSchool.ViewModel;

namespace WXSchool.Site.PC
{
    /// <summary> 
    /// 权限验证 
    /// </summary> 
    public class AuthAttribute : ActionFilterAttribute
    {
        /// <summary> 
        /// 角色 
        /// </summary> 
        public int Role { get; set; }

        public AuthAttribute(int requireRole)
        {
            Role = requireRole;
        }

        /// <summary> 
        /// 验证权限（action执行前会先执行这里） 
        /// </summary> 
        /// <param name="filterContext"></param> 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var content = new ContentResult();
            var authCookie = Cookie.Get(FormsAuthentication.FormsCookieName);//获取cookie
            //身份信息 
            if (authCookie == null)
            {
                content.Content = string.Format("<script type='text/javascript'>location.href = '/index.html?returnUrl={0}';</script>", HttpUtility.UrlEncode(HttpContext.Current.Request.RawUrl));
                filterContext.Result = content;
            }
            else
            {
                var ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                var user = JsonConvert.DeserializeObject<CurrentUserVM>(ticket.UserData);
                //角色校验
                if (Role == 90 && user.RoleType != 90)
                {
                    content.Content = string.Format("<script type='text/javascript'>alert('您无权限使用该功能！');location.href = '/index.html';</script>");
                    filterContext.Result = content;
                }
            }
            
            base.OnActionExecuting(filterContext);
        }
    } 
}