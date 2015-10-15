using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core.Persistence;
using WXSchool.Model.Meeting;

namespace WXSchool.Dal.Mee
{
    public class RegistrationsRespository : Respository<Registrations>
    {
        public IEnumerable<Registrations> Query(string openId)
        {
            var sql = @"select * from dbo.Registrations where OpenId=@openId";

            return base.GetList<Registrations>(sql, new { openId });
        }
    }
}
