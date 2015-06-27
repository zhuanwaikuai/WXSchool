using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core;
using TCBase.Saker.Core.AOP;
using WXSchool.Dal.Stu;
using WXSchool.Dto;
using WXSchool.Model;

namespace WXSchool.Bll.Stu
{
    [AOPClass]
    public class StudentBiz : TCBase.Saker.Core.Services.Service
    {
        readonly StudentInfoRespository _respository;

        public StudentBiz(StudentInfoRespository respository)
        {
            this._respository = respository;
        }

        /// <summary>
        /// 学生信息微信绑定
        /// </summary>
        /// <param name="name"></param>
        /// <param name="idCard"></param>
        /// <param name="mobile"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public virtual OperationResult Bind(string name, string idCard, string mobile, string openId)
        {
            IEnumerable<StudentInfo> list =
                _respository.QueryStudent(new StudentDto() {StudentName = name, IDCardNo = idCard});
            if (list==null||!list.Any())
            {
                return new OperationResult(OperationResultType.Error, "未找到该学生信息");
            }

            StudentInfo student = list.First();
            StudentBinding binding = new StudentBinding()
            {
                StudentId = student.StudentId,
                OpenId = openId,
                Mobile = mobile,
                CreateTime = DateTime.Now
            };
            var result = ClassFactory.GetInstance<StudentBindingRespository>().Add(binding);
            if (result > 0)
            {
                return new OperationResult(OperationResultType.Success, "绑定成功");
            }
            return new OperationResult(OperationResultType.Error, "绑定失败");
        }
    }
}
