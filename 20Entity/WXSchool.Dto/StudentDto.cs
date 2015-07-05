using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXSchool.Dto
{
    public class StudentDto
    {
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNo
        {
            set;
            get;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string StudentName
        {
            set;
            get;
        }

        /// <summary>
        /// 学校Id
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// 年级code
        /// </summary>
        public string GradeCode { get; set; }

        /// <summary>
        /// 班级名次
        /// </summary>
        public string ClassName { get; set; }
    }
}
