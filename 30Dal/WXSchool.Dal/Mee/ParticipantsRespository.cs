﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core.Persistence;
using WXSchool.Model.Meeting;

namespace WXSchool.Dal.Mee
{
    public class ParticipantsRespository : Respository<Participants>
    {
        public IEnumerable<Participants> Query(int registrationId)
        {
            var sql = @"select * from Participants where RegistrationId=@registrationId";

            return base.GetList<Participants>(sql, new {registrationId});
        }
    }
}
