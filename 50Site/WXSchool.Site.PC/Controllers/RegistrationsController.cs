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
    }
}
