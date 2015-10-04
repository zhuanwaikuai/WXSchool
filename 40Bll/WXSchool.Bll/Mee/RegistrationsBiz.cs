using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core;
using TCBase.Saker.Core.AOP;
using WXSchool.Dal.Mee;
using WXSchool.Model.Meeting;

namespace WXSchool.Bll.Mee
{
    [AOPClass]
    public class RegistrationsBiz
        : TCBase.Saker.Core.Services.Service
    {
        readonly RegistrationsRespository _respository;

        public RegistrationsBiz(RegistrationsRespository respository)
        {
            this._respository = respository;
        }

        public virtual IEnumerable<Registrations> GetRegistrationsList(string organizationName="")
        {
            IEnumerable<Registrations> list = _respository.GetAll();
            if (!string.IsNullOrWhiteSpace(organizationName))
            {
                list = list.Where(r => r.OrganizationName.Contains(organizationName));
            }

            return list.OrderByDescending(r => r.CreateTime);
        }

        public virtual Registrations GetRegistration(int rid)
        {
            var registration = _respository.GetEntityById(rid);
            if (registration==null)
            {
                registration=new Registrations();
            }

            return registration;
        }

        public virtual OperationResult Edit(Registrations registration)
        {
            string msg = "操作成功";
            try
            {
                if (registration.RegId > 0)
                {
                    var old = _respository.GetEntityById(registration.RegId);
                    if (old!=null)
                    {
                        registration.ProvinceCode = old.ProvinceCode;
                        registration.CityCode = old.CityCode;
                        registration.CountyCode = old.CountyCode;
                        registration.OpenId = old.OpenId;
                        registration.CreateTime = old.CreateTime;
                        registration.MeetingId = old.MeetingId;

                        _respository.Modify(registration);
                    }
                }
                else
                {
                    registration.CreateTime = DateTime.Now;
                    int regId = _respository.Add(registration);
                    registration.RegId = regId;
                    ParticipantsBiz pBiz = ClassFactory.GetInstance<ParticipantsBiz>();
                    for (int i = 0; i < registration.Participants; i++)
                    {
                        var par = new Participants();
                        par.RegistrationId = regId;
                        par.OpenId = registration.OpenId;
                        par.PName = "";
                        par.IDCardNo = "";
                        par.GroupCode = "";
                        par.GroupName = "";
                        par.Telephone = "";
                        pBiz.Edit(par);
                    }
                }
                return new OperationResult(OperationResultType.Success, msg, registration.RegId);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new OperationResult(OperationResultType.Error, msg);
        }
    }
}
