﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXSchool.ViewModel.Meeting
{
    public class ParticipantInfo
    {
        public string ProvinceName
        {
            set;
            get;
        }
        public string CityName
        {
            set;
            get;
        }
        public string CountyName
        {
            set;
            get;
        }
        public string HotelName
        {
            set;
            get;
        }
        public string TypeName
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
        /// 机构名称
        /// </summary>
        public string OrganizationName
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
        public string GroupName
        {
            set;
            get;
        }
    }
}
