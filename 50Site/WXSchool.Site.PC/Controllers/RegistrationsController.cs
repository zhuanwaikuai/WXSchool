using System;
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
    }
}
