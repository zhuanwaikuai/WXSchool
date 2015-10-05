using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCBase.Saker.Core;
using WXSchool.Bll;
using WXSchool.Bll.Mee;
using WXSchool.Model.Meeting;
using WXSchool.ViewModel.Meeting;

namespace WXSchool.Site.Mobile.Controllers
{
    public class MeetingController : BaseController<RegistrationsBiz>
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrate(int regId=0)
        {
            Registrations registration = _biz.GetRegistration(regId);
            if (regId == 0)
            {
                registration = new Registrations()
                {
                    OrganizationName = "",
                    HotelName = "",
                    IsBooking = 1,
                    HaveMeals = 1
                };
            }
            return View(registration);
        }

        [HttpPost]
        public ActionResult Registrate(Registrations registration)
        {
            registration.OpenId = "";
            registration.IsBooking = registration.IsBooking==0?1:0;
            registration.HaveMeals = registration.HaveMeals == 0 ? 1 : 0;
            OperationResult result = _biz.Edit(registration);
            return Json(result);
        }

        public ActionResult Preview(int regId)
        {
            var reg = new RegistrationInfo
            {
                Registration = _biz.GetRegistration(regId),
                ParticipantList = ClassFactory.GetInstance<ParticipantsBiz>().GetParticipantsList(regId)
            };
            return View(reg);
        }
    }
}
