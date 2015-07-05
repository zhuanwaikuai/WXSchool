using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXSchool.Bll;
using WXSchool.Bll.Stu;
using WXSchool.Model;

namespace WXSchool.Site.PC.Controllers
{
    public class StudentController : BaseController<StudentBiz>
    {
        public ActionResult Index()
        {
            OperationResult result = _biz.GetStudentList();
            if (result.ResultType == OperationResultType.Success)
            {
                var studentList = result.AppendData as List<StudentInfo>;
                return View(studentList);
            }
            return View();
        }

    }
}
