using System;

namespace WXSchool.Model.Meeting
{
    /// <summary>
    /// MeetingConfig:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MeetingConfig
    {
        #region Model
        /// <summary>
        /// PK 自增
        /// </summary>
        public int MCId
        {
            set;
            get;
        }
        /// <summary>
        /// 会议主题
        /// </summary>
        public string MCTitle
        {
            set;
            get;
        }
        /// <summary>
        /// 会议简介
        /// </summary>
        public string MCDescription
        {
            set;
            get;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime MCBeginTime
        {
            set;
            get;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime MCEndTime
        {
            set;
            get;
        }
        /// <summary>
        /// 会议地点
        /// </summary>
        public string MCAddress
        {
            set;
            get;
        }
        /// <summary>
        /// 备注，备用
        /// </summary>
        public string MCRemark
        {
            set;
            get;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime MCCreateTime
        {
            set;
            get;
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string MCCreator
        {
            set;
            get;
        }
        #endregion Model

    }
}

