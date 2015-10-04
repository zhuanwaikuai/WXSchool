using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WXSchool.Bll;
using WXSchool.Bll.Mee;
using WXSchool.Model.Meeting;

namespace WXSchool.Site.PC.Controllers
{
    public class HotelController : BaseController<HotelBiz>
    {
        public ActionResult Index()
        {
            IEnumerable<Hotel> list = _biz.GetHotelList();
            return View(list);
        }

        public ActionResult Edit(int hid = 0)
        {
            Hotel hotel = _biz.GetHotel(hid);
            return View(hotel);
        }

        [HttpPost]
        public ActionResult Edit(Hotel hotel)
        {
            OperationResult result = _biz.Edit(hotel);
            return Json(result);
        }

        public ActionResult Delete(int hid)
        {
            OperationResult result = _biz.Delete(hid);
            return Json(result);
        }

        public ActionResult Search(string hname)
        {
            IEnumerable<Hotel> list = _biz.GetHotelList(hname);
            var sb = new StringBuilder();
            foreach (var hotel in list)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", hotel.HName);
                sb.AppendFormat("<td>{0}</td>", hotel.HPrice);
                sb.AppendFormat("<td>{0}</td>", hotel.TotalRooms);
                sb.AppendFormat("<td>{0}</td>", hotel.BookedRooms);
                sb.AppendFormat("<td class='table-action'><a href='{0}'><i class='fa fa-pencil'></i></a> <a href='#' onclick='doDelete({1})' class='delete-row'><i class='fa fa-trash-o'></i></a></td>", Url.Action("Edit",new {hotel.HId}),hotel.HId);
                sb.Append("</tr>");
            }

            return Content(sb.ToString());
        }

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
                sb.AppendFormat("<option value='{0}' {2}>{1}</option>", item.HId, item.HName+" ("+item.HPrice+"元标准)", selected);
                selected = "";
            }

            return Content(sb.ToString());
        }
    }
}
