using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXSchool.Bll;
using WXSchool.Bll.Mee;
using WXSchool.Model.Meeting;

namespace WXSchool.Site.Mobile.Controllers
{
    public class ParticipantsController : BaseController<ParticipantsBiz>
    {
        public ActionResult Index(int regId)
        {
            ViewBag.RegId = regId;
            IEnumerable<Participants> list = _biz.GetParticipantsList(regId);
            return View(list);
        }

        public ActionResult Edit(int parId)
        {
            Participants participant = _biz.GetParticipants(parId);
            return View(participant);
        }

        [HttpPost]
        public ActionResult Edit(Participants participant)
        {
            participant.OpenId = "";
            OperationResult result = _biz.Edit(participant);
            return Json(result);
        }
    }
}
