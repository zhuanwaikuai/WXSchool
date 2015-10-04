using System;

namespace WXSchool.Model.Meeting
{
    /// <summary>
    /// Hotel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Hotel
    {
        #region Model
        /// <summary>
        /// PK 自增
        /// </summary>
        public int HId
        {
            set;
            get;
        }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HName
        {
            set;
            get;
        }
        /// <summary>
        /// 价格
        /// </summary>
        public int HPrice
        {
            set;
            get;
        }
        /// <summary>
        /// 总房间数
        /// </summary>
        public int TotalRooms
        {
            set;
            get;
        }
        /// <summary>
        /// 已订房间数
        /// </summary>
        public int BookedRooms
        {
            set;
            get;
        }
        /// <summary>
        /// 是否删除：0 否，1 是
        /// </summary>
        public int IsDeleted
        {
            set;
            get;
        }
        #endregion Model

    }
}

