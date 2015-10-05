using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WXSchool.Bll.Mee;
using WXSchool.Model.Meeting;

namespace WXSchool.Site.Mobile.Controllers
{
    public class HotelController : BaseController<HotelBiz>
    {
        public ActionResult SelectOption(int selectedId = 0)
        {
            IEnumerable<Hotel> list = _biz.GetHotelList();
            var sb = new StringBuilder();
            var selected = "";
            foreach (var item in list)
            {
                if (selectedId > 0 && item.HId == selectedId)
                {
                    selected = " selected='selected'";
                }
                sb.AppendFormat("<option data-id='{0}' value='{1}' {2}>{1} (剩余房间：{3}间)</option>", item.HId, item.HName + " (" + item.HPrice + "元标准)", selected, item.TotalRooms-item.BookedRooms);
                selected = "";
            }

            return Content(sb.ToString());
        }

    }
}
