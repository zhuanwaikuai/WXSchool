using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WXSchool.ViewModel;

namespace WeiXin.Bll
{
    /// <summary>
    /// 微信模板消息
    /// </summary>
    public class TemplateMsgBiz
    {
        private const string TopColor = "#1caf9a";
        private const string Color="#173177";

        #region 注册审核提醒
        /// <summary>
        /// 注册审核提醒
        /// </summary>
        public static void Check(string title, string result, string reason, string remark, string url, string touser)
        {
            var template = new TemplateMsg
            {
                touser = touser,
                template_id = "_9lqF7ZrDvTHukaBhaDAtsiFxXA0j_Lj-Z_hU2s3u4g",
                url = url,
                topcolor = TopColor,
                data = new TemplateNotes
                {
                    first = new TemplateNote { value = title,color = Color},
                    keyword1 = new TemplateNote { value = result, color = Color },
                    keyword2 = new TemplateNote { value = reason, color = Color },
                    remark = new TemplateNote { value = remark, color = Color },
                }
            };

            WeiXinBiz.SendTemplateMsg(template);
        }
        #endregion
    }
}
