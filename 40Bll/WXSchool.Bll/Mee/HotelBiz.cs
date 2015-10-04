using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core.AOP;
using WXSchool.Dal.Mee;
using WXSchool.Model.Meeting;

namespace WXSchool.Bll.Mee
{
    [AOPClass]
    public class HotelBiz: TCBase.Saker.Core.Services.Service
    {
        readonly HotelRespository _respository;

        public HotelBiz(HotelRespository respository)
        {
            this._respository = respository;
        }

        public virtual IEnumerable<Hotel> GetHotelList(string name = "")
        {
            IEnumerable<Hotel> list = _respository.GetAll()
                .Where(h=>h.IsDeleted==0);
            if (!string.IsNullOrWhiteSpace(name))
            {
                return list.Where(h => h.HName.Contains(name));
            }

            return list;
        }

        public virtual Hotel GetHotel(int hid)
        {
            var hotel = _respository.GetEntityById(hid);
            if (hotel==null)
            {
                hotel=new Hotel();
            }

            return hotel;
        }

        public virtual OperationResult Edit(Hotel hotel)
        {
            string msg = "操作成功";
            try
            {
                if (hotel.HId>0)
                {
                    _respository.Modify(hotel);
                }
                else
                {
                    _respository.Add(hotel);
                }
                return new OperationResult(OperationResultType.Success, msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new OperationResult(OperationResultType.Error, msg);
        }

        public virtual OperationResult Delete(int hid)
        {
            var hotel = _respository.GetEntityById(hid);
            if (hotel!=null & hotel.HId>0)
            {
                hotel.IsDeleted = 1;
                _respository.Modify(hotel);
                return new OperationResult(OperationResultType.Success, "操作成功");
            }

            return new OperationResult(OperationResultType.Error, "未找到酒店");
        }
    }
}
