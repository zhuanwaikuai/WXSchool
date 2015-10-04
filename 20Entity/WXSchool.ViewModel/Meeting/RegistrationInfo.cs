using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WXSchool.Model.Meeting;

namespace WXSchool.ViewModel.Meeting
{
    public class RegistrationInfo
    {
        public Registrations Registration;

        public IEnumerable<Participants> ParticipantList;
    }
}
