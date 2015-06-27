using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QJZ.Framework.Utility;
using TCBase.Saker.Core;
using WXSchool.Dal.Sys;
using WXSchool.Model;
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

        #region 家长绑定成功通知
        /// <summary>
        /// 家长绑定成功通知
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="studentName"></param>
        /// <param name="mobile"></param>
        /// <param name="orgId"></param>
        public static void ParentBind(string openId, string studentName, string mobile, int orgId)
        {
            var respository = ClassFactory.GetInstance<SysAccessTokenRespository>();
            SysAccessToken token = respository.GetEntityById(orgId);
            if (token==null)
            {
                Log4Helper.Write(string.Format("未找到机构{0}的微信配置信息", orgId), LogMessageType.Error);
                return;
            }

            var template = new TemplateMsg
            {
                touser = openId,
                template_id = token.TemplateId1,
                topcolor = TopColor,
                data = new TemplateNotes
                {
                    first = new TemplateNote { value = "恭喜！你已成功关联您的孩子！", color = Color },
                    keyword1 = new TemplateNote { value = studentName, color = Color },
                    keyword2 = new TemplateNote { value = mobile, color = Color },
                    keyword3 = new TemplateNote { value = DateTime.Now.ToString("yyyy-MM-dd HH:mm"), color = Color },
                    remark = new TemplateNote { value = "感谢你的使用。", color = Color },
                }
            };

            WeiXinBiz.SendTemplateMsg(template, token);
        }
        #endregion
    }
}
