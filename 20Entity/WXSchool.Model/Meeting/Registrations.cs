using System;

namespace WXSchool.Model.Meeting
{
    /// <summary>
    /// Registrations:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Registrations
    {
        #region Model
        /// <summary>
        /// PK 自增
        /// </summary>
        public int RegId
        {
            set;
            get;
        }
        /// <summary>
        /// 所参加会议
        /// </summary>
        public int MeetingId
        {
            set;
            get;
        }
        /// <summary>
        /// 省
        /// </summary>
        public string ProvinceCode
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProvinceName
        {
            set;
            get;
        }
        /// <summary>
        /// 市
        /// </summary>
        public string CityCode
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityName
        {
            set;
            get;
        }
        /// <summary>
        /// 县
        /// </summary>
        public string CountyCode
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountyName
        {
            set;
            get;
        }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrganizationName
        {
            set;
            get;
        }
        /// <summary>
        /// 参会人数
        /// </summary>
        public int Participants
        {
            set;
            get;
        }
        /// <summary>
        /// 是否代预订酒店
        /// </summary>
        public int IsBooking
        {
            set;
            get;
        }
        /// <summary>
        /// 酒店
        /// </summary>
        public int HotelId
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string HotelName
        {
            set;
            get;
        }
        /// <summary>
        /// 房间数量
        /// </summary>
        public int BookedRooms
        {
            set;
            get;
        }
        /// <summary>
        /// 住宿天数
        /// </summary>
        public int LodgingDays
        {
            set;
            get;
        }
        /// <summary>
        /// 是否留下用餐
        /// </summary>
        public int HaveMeals
        {
            set;
            get;
        }
        /// <summary>
        /// OpenId
        /// </summary>
        public string OpenId
        {
            set;
            get;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set;
            get;
        }
        #endregion Model

    }
}

