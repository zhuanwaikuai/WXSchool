using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WXSchool.Model;
using WXSchool.ViewModel;

namespace WeiXin.Bll
{
    public class CustomerMsgBiz
    {
        /// <summary>
        /// 图文消息
        /// </summary>
        /// <param name="token">机构的微信配置信息</param>
        /// <param name="openId"></param>
        /// <param name="articles"></param>
        public static void SendNews(SysAccessToken token, string openId, params Article[] articles)
        {
            var news = new CustomerNewsMsg
            {
                touser = openId,
                msgtype = "news",
                news = new News
                {
                    articles = articles
                }
            };

            WeiXinBiz.SendCustomerMsg(news, token);
        }
    }
}
