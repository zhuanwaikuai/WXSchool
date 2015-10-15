using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core.Persistence;
using WXSchool.Model.Meeting;
using WXSchool.ViewModel.Meeting;

namespace WXSchool.Dal.Mee
{
    public class ParticipantsRespository : Respository<Participants>
    {
        public IEnumerable<Participants> Query(int registrationId)
        {
            var sql = @"select * from Participants where RegistrationId=@registrationId";

            return base.GetList<Participants>(sql, new {registrationId});
        }

        public IEnumerable<ParticipantInfo> Query()
        {
            var sql = @"select b.OrganizationName,a.GroupName,a.PName
                    ,a.Gender,a.IDCardNo,a.Telephone
                    from dbo.Participants a 
                    join dbo.Registrations b on a.RegistrationId=b.RegId";
            return base.GetList<ParticipantInfo>(sql);
        }
    }
}
