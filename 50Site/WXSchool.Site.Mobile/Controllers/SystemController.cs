using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TCBase.Saker.Core;
using WXSchool.Bll.Sys;

namespace WXSchool.Site.Mobile.Controllers
{
    public class SystemController : Controller
    {
        public ActionResult SelectOption(int groupId, int selectedId = 0)
        {
            var biz = ClassFactory.GetInstance<SysParametersBiz>();
            var list = biz.GetByGroup(groupId);
            var sb = new StringBuilder();
            var selected = "";
            foreach (var item in list)
            {
                if (selectedId > 0 && item.PId == selectedId)
                {
                    selected = " selected='selected'";
                }
                sb.AppendFormat("<option data-id='{0}' value='{1}' {2}>{1}</option>", item.PId, item.PName, selected);
                selected = "";
            }

            return Content(sb.ToString());
        }
    }
}
