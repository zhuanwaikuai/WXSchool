using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core.Persistence;
using WXSchool.Dto;
using WXSchool.Model;

namespace WXSchool.Dal.Stu
{
    public class StudentInfoRespository : Respository<StudentInfo>
    {
        /// <summary>
        /// 学生基本信息查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IEnumerable<StudentInfo> QueryStudent(StudentDto dto)
        {
            var sql = new StringBuilder("select * from dbo.StudentInfo where 1=1");
            if (!string.IsNullOrWhiteSpace(dto.IDCardNo))
            {
                sql.Append(" and IDCardNo=@IDCardNo");
            }
            if (!string.IsNullOrWhiteSpace(dto.StudentName))
            {
                sql.Append(" and StudentName=@StudentName");
            }
            return base.GetList<StudentInfo>(sql.ToString(), dto);
        }

        /// <summary>
        /// 学生列表查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IEnumerable<StudentInfo> QueryStudentList(StudentDto dto)
        {
            var sql = new StringBuilder("select * from dbo.StudentInfo where 1=1");
            if (!string.IsNullOrWhiteSpace(dto.ClassName))
            {
                sql.Append(" and ClassName=@ClassName");
            }
            return base.GetList<StudentInfo>(sql.ToString(), dto);
        }
    }
}
