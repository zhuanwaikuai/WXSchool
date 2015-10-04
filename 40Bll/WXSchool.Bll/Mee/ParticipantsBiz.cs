﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core.AOP;
using WXSchool.Dal.Mee;
using WXSchool.Model.Meeting;

namespace WXSchool.Bll.Mee
{
    [AOPClass]
    public class ParticipantsBiz
        : TCBase.Saker.Core.Services.Service
    {
        readonly ParticipantsRespository _respository;

        public ParticipantsBiz(ParticipantsRespository respository)
        {
            this._respository = respository;
        }

        public virtual IEnumerable<Participants> GetParticipantsList(int registrationId)
        {
            return _respository.Query(registrationId);
        }

        public virtual Participants GetParticipants(int regId)
        {
            var participant = _respository.GetEntityById(regId);
            if (participant == null)
            {
                participant = new Participants();
            }

            return participant;
        }

        public virtual OperationResult Edit(Participants participant)
        {
            string msg = "操作成功";
            try
            {
                if (participant.ParId > 0)
                {
                    participant.CreateTime = DateTime.Now;
                    _respository.Modify(participant);
                }
                else
                {
                    participant.CreateTime = DateTime.Now;
                    _respository.Add(participant);
                }
                return new OperationResult(OperationResultType.Success, msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new OperationResult(OperationResultType.Error, msg);
        }
    }
}
