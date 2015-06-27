using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXSchool.ViewModel
{
    public class TemplateMsg
    {
        public string touser;
        public string template_id;
        public string url;
        public string topcolor;
        public TemplateNotes data;
    }

    public class TemplateNotes
    {
        public TemplateNote first;
        public TemplateNote keyword1;
        public TemplateNote keyword2;
        public TemplateNote keyword3;
        public TemplateNote remark;
    }

    public class TemplateNote
    {
        public string value;
        public string color;
    }
}
