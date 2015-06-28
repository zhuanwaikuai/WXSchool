using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXSchool.ViewModel
{
    /// <summary>
    /// 客服图文消息
    /// </summary>
    public class CustomerNewsMsg
    {
        public string touser;
        public string msgtype;
        public News news;
    }

    public class News
    {
        public Article[] articles;
    }

    public class Article
    {
        public string title;
        public string description;
        public string url;
        public string picurl;
    }
}
