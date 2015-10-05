using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXSchool.Model.Sys
{
    [Serializable]
    public partial class SysParameters
    {
        #region Model
        /// <summary>
        /// PK 自增
        /// </summary>
        public int PId
        {
            set;
            get;
        }
        /// <summary>
        /// 组别
        /// </summary>
        public int GroupId
        {
            set;
            get;
        }
        public string GroupName
        {
            set;
            get;
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string PName
        {
            set;
            get;
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            set;
            get;
        }
        public int IsDeleted
        {
            set;
            get;
        }
        #endregion Model

    }
}
