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

        public virtual Registrations GetUserRegistrations(string openId)
        {
            IEnumerable<Registrations> list = _respository.Query(openId);
            if (list==null || !list.Any())
            {
                return null;
            }

            return list.First();
        }

        public virtual OperationResult Submit(int regId)
        {
            var registration = _respository.GetEntityById(regId);
            registration.Status = 10;
            _respository.Modify(registration);

            return new OperationResult(OperationResultType.Success, "操作成功");
        }

        public virtual OperationResult Sign(string openId)
        {
            var registration = GetUserRegistrations(openId);
            if (registration == null)
            {
                return new OperationResult(OperationResultType.Error, "未找到您的报名信息");
            }

            registration.Status = 20;
            _respository.Modify(registration);

            return new OperationResult(OperationResultType.Success, "签到成功");
        }

        public virtual OperationResult Edit(Registrations registration)
        {
            string msg = "操作成功";
            try
            {
                HotelBiz hotelBiz = ClassFactory.GetInstance<HotelBiz>();
                Hotel hotel = hotelBiz.GetHotel(registration.HotelId);
                //剩余房间
                int surplus = hotel.TotalRooms - hotel.BookedRooms;

                if (registration.IsBooking == 0)
                {
                    registration.BookedRooms = 0;
                    registration.LodgingDays = 0;
                    registration.HotelId = 0;
                    registration.HotelName = "";
                }

                if (registration.RegId > 0)
                {
                    var old = _respository.GetEntityById(registration.RegId);
                    if (old != null)
                    {
                        #region 酒店房间校验
                        //酒店房间校验：换酒店
                        if (registration.HotelId != old.HotelId)
                        {
                            if (registration.BookedRooms > surplus)
                            {
                                return new OperationResult(OperationResultType.Error, string.Format("房间不足，还剩{0}间", surplus));
                            }

                            //更新已订房间数
                            hotel.BookedRooms += registration.BookedRooms;
                            hotelBiz.Edit(hotel);
                            //老酒店，退房间
                            Hotel oldHotel = hotelBiz.GetHotel(old.HotelId);
                            oldHotel.BookedRooms -= old.BookedRooms;
                            hotelBiz.Edit(oldHotel);
                        }
                        //酒店房间校验：原酒店，房间数变动
                        else if (registration.BookedRooms != old.BookedRooms)
                        {
                            if (registration.BookedRooms - old.BookedRooms > surplus)
                            {
                                return new OperationResult(OperationResultType.Error, string.Format("房间不足，还剩{0}间", surplus));
                            }

                            //更新已订房间数
                            hotel.BookedRooms += registration.BookedRooms - old.BookedRooms;
                            hotelBiz.Edit(hotel);
                        }
                        
                        #endregion

                        registration.ProvinceCode = old.ProvinceCode;
                        registration.CityCode = old.CityCode;
                        registration.CountyCode = old.CountyCode;
                        registration.OpenId = old.OpenId;
                        registration.CreateTime = old.CreateTime;
                        registration.MeetingId = old.MeetingId;

                        _respository.Modify(registration);

                        //人员数发生改变
                        if (registration.Participants!=old.Participants)
                        {
                            ParticipantsBiz pBiz = ClassFactory.GetInstance<ParticipantsBiz>();
                            pBiz.Delete(registration.RegId);
                            for (int i = 0; i < registration.Participants; i++)
                            {
                                var par = new Participants();
                                par.RegistrationId = registration.RegId;
                                par.OpenId = registration.OpenId;
                                par.PName = "";
                                par.IDCardNo = "";
                                par.PGroupCode = registration.GroupCode;
                                par.GroupCode = "";
                                par.GroupName = "";
                                par.Telephone = "";
                                pBiz.Edit(par);
                            }
                        }
                    }
                }
                else
                {
                    //酒店房间校验
                    if (registration.BookedRooms > surplus)
                    {
                        return new OperationResult(OperationResultType.Error, string.Format("房间不足，还剩{0}间", surplus));
                    }

                    registration.CreateTime = DateTime.Now;
                    int regId = _respository.Add(registration);
                    registration.RegId = regId;

                    //更新已订房间数
                    if (registration.BookedRooms>0)
                    {
                        hotel.BookedRooms += registration.BookedRooms;
                        hotelBiz.Edit(hotel);
                    }

                    ParticipantsBiz pBiz = ClassFactory.GetInstance<ParticipantsBiz>();
                    for (int i = 0; i < registration.Participants; i++)
                    {
                        var par = new Participants();
                        par.RegistrationId = regId;
                        par.OpenId = registration.OpenId;
                        par.PName = "";
                        par.IDCardNo = "";
                        par.PGroupCode = registration.GroupCode;
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
