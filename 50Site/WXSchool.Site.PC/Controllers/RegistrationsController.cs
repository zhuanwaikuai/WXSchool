using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TCBase.Saker.Core;
using WXSchool.Bll;
using WXSchool.Bll.Mee;
using WXSchool.Model.Meeting;
using WXSchool.ViewModel.Meeting;

namespace WXSchool.Site.PC.Controllers
{
    public class RegistrationsController : BaseController<RegistrationsBiz>
    {
        public ActionResult Index()
        {
            IEnumerable<Registrations> list = _biz.GetRegistrationsList();
            return View(list);
        }

        public ActionResult Edit(int regId)
        {
            var reg = new RegistrationInfo
            {
                Registration = _biz.GetRegistration(regId),
                ParticipantList = ClassFactory.GetInstance<ParticipantsBiz>().GetParticipantsList(regId)
            };
            return View(reg);
        }

        [HttpPost]
        public ActionResult Edit(Registrations registration)
        {
            OperationResult result = _biz.Edit(registration);
            return Json(result);
        }

        public ActionResult Search(string orgName)
        {
            IEnumerable<Registrations> list = _biz.GetRegistrationsList(orgName);
            var sb = new StringBuilder();
            foreach (var reg in list)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", reg.OrganizationName);
                sb.AppendFormat("<td>{0}</td>", reg.ProvinceName+reg.CityName+reg.CountyName);
                sb.AppendFormat("<td>{0}</td>", reg.Participants);
                sb.AppendFormat("<td>{0}</td>", reg.IsBooking==1?"是":"否");
                sb.AppendFormat("<td class='table-action'><a href='{0}'><i class='fa fa-pencil'></i></a></td>", Url.Action("Edit", new { reg.RegId }));
                sb.Append("</tr>");
            }

            return Content(sb.ToString());
        }

        public FileResult ExportExcel()
        {
            var sbHtml = new StringBuilder();
            IEnumerable<ParticipantInfo> list = ClassFactory.GetInstance<ParticipantsBiz>().GetParticipants();
            sbHtml.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            sbHtml.Append("<tr>");
            var lstTitle = new List<string> { "省", "市", "县", "类别", "单位名称", "酒店", "住宿天数", "组别", "姓名", "身份证号码", "性别", "手机号" };
            foreach (var item in lstTitle)
            {
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", item);
            }
            sbHtml.Append("</tr>");

            foreach (var item in list)
            {
                sbHtml.Append("<tr>");
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.ProvinceName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.CityName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.CountyName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.TypeName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.OrganizationName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.HotelName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.LodgingDays);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.GroupName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.PName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.IDCardNo);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.Gender==1?"男":"女");
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", item.Telephone);
                sbHtml.Append("</tr>");
            }
            sbHtml.Append("</table>");

            //第一种:使用FileContentResult
            byte[] fileContents = Encoding.Default.GetBytes(sbHtml.ToString());
            Response.ContentEncoding = Encoding.GetEncoding("gb2312");
            Response.Charset = "gb2312";
            return File(fileContents, "application/ms-excel; charset=gb2312", "报名人员.xls");
        }
    }
}
