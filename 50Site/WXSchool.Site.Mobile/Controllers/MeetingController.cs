using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCBase.Saker.Core;
using WeiXin.Bll;
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
            if (string.IsNullOrWhiteSpace(CurrentUser.OpenId))
            {
                string url = AuthorizeUrl.GetOauth2BaseUrl(Request.Url.ToString());
                return Redirect(url);
            }

            Registrations registration = new Registrations()
            {
                OrganizationName = "",
                HotelName = "",
                IsBooking = 1,
                HaveMeals = 1
            };

            if (regId == 0)
            {
                Registrations reg2 = _biz.GetUserRegistrations(CurrentUser.OpenId);
                if (reg2 != null && reg2.RegId > 0)
                {
                    //if (DateTime.Now<new DateTime(2015,10,20))
                    //{
                        return RedirectToAction("Preview", new { reg2.RegId });
                    //}
                    //else
                    //{
                    //    return RedirectToAction("Index", "Pay");
                    //}
                }
            }
            else
            {
                registration = _biz.GetRegistration(regId);
            }
            ViewBag.Total = ClassFactory.GetInstance<ParticipantsBiz>().TotoalParticipants();
            return View(registration);
        }

        [HttpPost]
        public ActionResult Registrate(Registrations registration)
        {
            registration.OpenId = CurrentUser.OpenId;
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

        [HttpPost]
        public ActionResult Submit(int regId)
        {
            OperationResult result = _biz.Submit(regId);
            return Json(result);
        }

        public ActionResult Sign()
        {
            if (string.IsNullOrWhiteSpace(CurrentUser.OpenId))
            {
                string url = AuthorizeUrl.GetOauth2BaseUrl(Request.Url.ToString());
                return Redirect(url);
            }

            OperationResult result = _biz.Sign(CurrentUser.OpenId);
            ViewBag.Result = result.Message;
            return View();
        }
    }
}
