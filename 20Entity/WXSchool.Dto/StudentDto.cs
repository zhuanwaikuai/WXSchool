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
    }
}
