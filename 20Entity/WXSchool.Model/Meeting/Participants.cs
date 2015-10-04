using System;

namespace WXSchool.Model.Meeting
{
    /// <summary>
    /// Participants:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Participants
    {
        #region Model
        /// <summary>
        /// PK 自增
        /// </summary>
        public int ParId
        {
            set;
            get;
        }
        /// <summary>
        /// 所属报名
        /// </summary>
        public int RegistrationId
        {
            set;
            get;
        }
        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string OpenId
        {
            set;
            get;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PName
        {
            set;
            get;
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNo
        {
            set;
            get;
        }
        /// <summary>
        /// 性别：1 男，2 女
        /// </summary>
        public int Gender
        {
            set;
            get;
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone
        {
            set;
            get;
        }
        /// <summary>
        /// 组别
        /// </summary>
        public string GroupCode
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupName
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

