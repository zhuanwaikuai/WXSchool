using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXSchool.Bll;
using WXSchool.Bll.Mee;
using WXSchool.Model.Meeting;

namespace WXSchool.Site.PC.Controllers
{
    public class ParticipantsController : BaseController<ParticipantsBiz>
    {
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
